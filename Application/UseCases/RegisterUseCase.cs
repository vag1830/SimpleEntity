using System;
using System.Threading.Tasks;
using Application.Boundaries.Services;
using Application.Boundaries.UseCases.Register;
using Domain.Entities;

namespace Application.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IRegisterOutputHandler _outputHandler;
        private readonly IUserService _userService;

        public RegisterUseCase(IRegisterOutputHandler outputHandler, IUserService userService)
        {
            _outputHandler = outputHandler;
            _userService = userService;
        }

        public async Task Execute(RegistrationInput input)
        {
            //var user = await _userService.FindByName(input.UserName);

            //if (user != null)
            //{
            //    _outputHandler.Error("Unable to create User.");
            //}

            var user = new SimpleEntityUser
            {
                Email = input.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "username"
            };

            try
            {
                var createdUser = await _userService.Create(user, input.Password);

                _outputHandler.Handle(createdUser);
            }
            catch (Exception ex)
            {
                _outputHandler.Error(ex.Message);
            }
        }
    }
}
