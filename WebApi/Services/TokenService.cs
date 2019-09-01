using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using WebApi;

namespace WebApi.Services
{
    public class TokenService
    {
        public JwtSecurityToken CreateToken(SimpleEntityUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asafekeyfromconfiguration"));

            var token = new JwtSecurityToken(
                issuer: "https://simpleEntity.com",
                audience: "https://simpleEntity.com",
                expires: DateTime.UtcNow.AddMinutes(15),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
