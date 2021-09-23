using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Application.Abstractions;
using UserIdentityService.Domain.EntityModels.User;
using UserIdentityService.Domain.Requests;
using UserIdentityService.Domain.Responses;
using UserIdentityService.Infrastructure.Persistence;

namespace UserIdentityService.Infrastructure.Services {
  public class SecurityService : ISecurityService {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly UserIdentityServiceContext _context;
    private readonly IClaimService _claimService;
    private readonly ILogger<SecurityService> _logger;

    public SecurityService(UserManager<ApplicationUser> userManager,
        UserIdentityServiceContext context,
        IClaimService claimService,
        ILogger<SecurityService> logger) {
      _userManager = userManager;
      _context = context;
      _claimService = claimService;
      _logger = logger;
    }

    public async Task<UserManagerResponse> LoginAsync(LoginRequest request) {
      var user = await _userManager.FindByEmailAsync(request.Email);

      if (user is null) {
        return new UserManagerResponse("Пользователь с таким электронным адресом не найден", false);
      }

      var passPasswordValidation = await _userManager.CheckPasswordAsync(user, request.Password);

      if (!passPasswordValidation) {
        return new UserManagerResponse("Логин или пароль введены неверно", false);
      }

      var roles = await _userManager.GetRolesAsync(user);

      return await _claimService.GetClaims(user, roles.ToArray());
    }

    public async Task<UserManagerResponse> RegisterAsync(RegisterRequest request) {
      _logger.LogInformation(nameof(RegisterAsync) + " started");
      if (request is null) {
        throw new ArgumentNullException($"Register request is null");
      }

      if (request.Password != request.ConfirmPassword) {
        return new UserManagerResponse("Пароли не совпадают", false);
      }

      var identityUser = new ApplicationUser {
        Email = request.Email,
        UserName = request.Email
      };

      var registerResult = await _userManager.CreateAsync(identityUser, request.Password);

      if (registerResult.Succeeded) {
        _logger.LogInformation($"User registered!", identityUser.UserName);
        await _userManager.AddToRoleAsync(identityUser, request.Role);
        _logger.LogInformation("User set role client");
        return await _claimService.GetClaims(identityUser, request.Role);
      }

      var errors = new StringBuilder();
      if (registerResult.Errors is not null) {
        foreach (var error in registerResult.Errors) errors.Append(error.Description);
      }

      _logger.LogInformation(nameof(RegisterAsync) + " finished");
      return new UserManagerResponse(errors.ToString(), false);
    }
  }
}
