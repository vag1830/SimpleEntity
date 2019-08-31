using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.Authenticate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticateOutputHandler _presenter;
        private readonly IAuthenticateUseCase _useCase;

        public AuthenticationController(IAuthenticateUseCase useCase, AuthenticateOutputHandler presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpPost]
        [Route("tokens")]
        public async Task<IActionResult> CreateToken([FromBody] CreateTokenRequest request)
        {
            var input = new AuthenticationInput(request.UserName, request.Password);

            await _useCase.Execute(input);

            return _presenter.ViewModel;
        }
    }
}