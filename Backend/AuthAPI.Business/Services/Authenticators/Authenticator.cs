using AuthAPI.Business.Services.TokenGenerators;
using AuthAPI.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Business.Services.Authenticators
{
    public class Authenticator
    {
        private readonly AccessTokenGenerator _accessTokenGenerator;
        public Authenticator(AccessTokenGenerator accessTokenGenerator)
        {
            _accessTokenGenerator = accessTokenGenerator;
            
        }
        public async Task<string> Authenticate(User user)
        {
            string accessToken = _accessTokenGenerator.GenerateToken(user);

            
            if (accessToken != null)
            {
                return accessToken;
            }
            else
            {
                return null;
            }

        }
    }
}
