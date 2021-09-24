﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentityService.Api.Models.Responses {
  public class UserManagerResponse {

    public UserManagerResponse(string message, bool success = false) {
      Message = message;
      Success = success;
    }

    public UserManagerResponse(string token, bool success, DateTime? expiredDate) {
      Token = token;
      Success = success;
      ExpiredDate = expiredDate;
    }

    public string Message { get; set; }
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public string Token { get; set; }
    public DateTime? ExpiredDate { get; set; }
  }
}
