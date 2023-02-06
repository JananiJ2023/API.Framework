using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework.Models
{
    public partial class RegisterUserReq
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
