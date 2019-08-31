using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.Authenticate;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.UseCases.Authenticate
{
    public class AuthenticateOutputHandler : IAuthenticateOutputHandler
    {
        public IActionResult ViewModel;

        public Task Handle(SimpleEntityUser output)
        {
            var token = GenerateToken(output);

            var response = new CreateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo
            };

            ViewModel = new CreatedResult("https://simpleEntity.com", response);

            return Task.CompletedTask;
        }

        public Task Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);

            return Task.CompletedTask;
        }

        // TODO: Implement and inject a tokenService.
        private JwtSecurityToken GenerateToken(SimpleEntityUser user)
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
