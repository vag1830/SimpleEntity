using System.Threading.Tasks;
using Application.Boundaries.Services;
using Application.Boundaries.UseCases.Authenticate;

namespace Application.UseCases
{
    public class AuthenticateUseCase : IAuthenticateUseCase
    {
        private IAuthenticateOutputHandler _outputHandler;
        private IUserService _userService;

        public AuthenticateUseCase(IAuthenticateOutputHandler outputHandler, IUserService userService)
        {
            _outputHandler = outputHandler;
            _userService = userService;
        }

        public async Task Execute(AuthenticationInput input)
        {
            var user = await _userService.FindByName(input.UserName);

            if (user != null && await _userService.CheckPassword(user, input.Password))
            {
                await _outputHandler.Handle(user);
            }
            else
            {
                await _outputHandler.Error("Not Authenticated");
            }
        }
    }
}
