using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IntegrationTest
{
    public static class SwtTokenService
    {
        private static readonly string _secretkeydata= "Ghdsajhdkashjdashj873264623fgdjhb2gi178t787g@!#@!ED@!@D#@$#@F@#(((&*)(&%$#$@#RFSDAFSDFSD+++_____)))CF)SD(F(DS)";

        public static string JwtGenerator(string customerid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customerid),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretkeydata)), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        public static string GetUserId(ClaimsPrincipal principal)
        {
            return
                principal.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        }
    }

}
