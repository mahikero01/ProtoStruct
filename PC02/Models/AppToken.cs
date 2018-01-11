using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PC02.Models
{
    public class AppToken
    {
        public String TokenName { get; set; }
        public String Token { get; set; }
    }
}
