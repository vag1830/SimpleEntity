using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Boundaries.UseCases.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUseCase _useCase;
        private readonly RegisterOutputHandler _presenter;

        public UsersController(IRegisterUseCase useCase, RegisterOutputHandler presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            var input = new RegistrationInput(request.UserName, request.Password, request.Email);

            await _useCase.Execute(input);

            return _presenter.ViewModel;
        }

    }
}