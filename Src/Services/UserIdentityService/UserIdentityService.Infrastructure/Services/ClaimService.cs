using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Application.Abstractions;
using UserIdentityService.Domain.EntityModels.User;
using UserIdentityService.Domain.Responses;

namespace UserIdentityService.Infrastructure.Services {
  public class ClaimService : IClaimService {
    private readonly IConfiguration _configuration;

    public ClaimService(IConfiguration configuration) {
      _configuration = configuration;
    }

    public async Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles) {
      await Task.Yield();
      var claims = new List<Claim>
      {
                new("Email", user.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
      };

      foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

      var key = Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]);
      var secret = new SymmetricSecurityKey(key);
      var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

      var tokenOption = new JwtSecurityToken(
          _configuration["AuthSettings:Issuer"],
          _configuration["AuthSettings:Audience"],
          claims,
          expires: DateTime.Now
            .AddMinutes(Convert.ToDouble(_configuration["AuthSettings:ExpiredInMinutes"]))
            .AddDays(1),
          signingCredentials: signingCredentials);

      var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

      return new UserManagerResponse(tokenString, true, tokenOption.ValidTo);
    }
  }
}
