using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Boundaries.UseCases.Register;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;

namespace WebApi.UseCases.Register
{
    public class RegisterOutputHandler : IRegisterOutputHandler
    {
        public IActionResult ViewModel;
        private readonly TokenService _tokenService;

        public RegisterOutputHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public void Handle(SimpleEntityUser output)
        {
            var token = _tokenService.CreateToken(output);

            var response = new RegistrationResponse
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