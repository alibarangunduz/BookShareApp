using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Business.Services.TokenGenerators
{
    public class AuthenticationConfiguration
    {
        public string AccessTokenSecret { get; set; }
        public double AccessTokenExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
