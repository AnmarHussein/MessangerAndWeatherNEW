using Core.DTO;
using Core.Repoisitory;
using Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace infra.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepoisitory _authentication;
        public AuthenticationService(IAuthenticationRepoisitory authentication)
        {
            _authentication = authentication;
        }
        public async Task<string> Auth_jwt(AUTH auth)
        {
            var authun = await _authentication.GetAuth(auth);
            if (authun == null)
                return null;

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Email, authun.USERNAME),
                    new Claim(ClaimTypes.Role, authun.ROLENAME),
                    new Claim(ClaimTypes.Name, authun.ID.ToString())

                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }
    }
}
