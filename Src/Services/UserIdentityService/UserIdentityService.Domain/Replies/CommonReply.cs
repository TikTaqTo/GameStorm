using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentityService.Domain.Replies {
  public class CommonReply {
    public IEnumerable<string> Errors { get; set; }
    public IEnumerable<string> Warnings { get; set; }
  }
}
