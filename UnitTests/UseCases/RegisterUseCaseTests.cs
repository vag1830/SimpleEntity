using System.Threading.Tasks;
using Application.Boundaries.UseCases.Register;
using Application.UseCases;
using FluentAssertions;
using Infrastructure.Services;
using UnitTests.Services;
using UnitTests.UseCases.Authenticate;
using Xunit;

namespace UnitTests.UseCases
{
    public class RegisterUseCaseTests
    {
        [Fact]
        public async Task RegsiterUseCase_UserAlreadyExists_ShouldReturnError()
        {
            // Arrange
            var userService = new FakeInvalidUserNameUserService();
            var presenter = new FakeRegisterOutputHandler();

            var sut = new RegisterUseCase(presenter, userService);

            var input = new RegistrationInput("username", "password", "email@domain.com");

            // Act
            await sut.Execute(input);

            // Assert
            presenter.ErrorMessage
                .Should()
                .Be(userService.ErrorMessage);

            presenter.ViewModel
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task RegsiterUseCase_ValidInput_ShouldReturnTheUser()
        {
            // Arrange
            var userService = new FakeUserService();
            var presenter = new FakeRegisterOutputHandler();

            var sut = new RegisterUseCase(presenter, userService);

            var input = new RegistrationInput("username", "password", "email@domain.com");

            // Act
            await sut.Execute(input);

            // Assert
            presenter.ErrorMessage
                .Should()
                .BeNull();

            presenter.ViewModel
                .Should()
                .BeEquivalentTo(userService.User);
        }
    }
}
