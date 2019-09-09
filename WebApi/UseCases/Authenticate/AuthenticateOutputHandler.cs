using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Boundaries.UseCases.Authenticate;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;

namespace WebApi.UseCases.Authenticate
{
    public class AuthenticateOutputHandler : IAuthenticateOutputHandler
    {
        public IActionResult ViewModel;
        private readonly TokenService _tokenService;

        public AuthenticateOutputHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public void Handle(SimpleEntityUser output)
        {
            var token = _tokenService.CreateToken(output);

            var response = new CreateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo
            };

            ViewModel = new CreatedResult("https://simpleEntity.com", response);
        }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
