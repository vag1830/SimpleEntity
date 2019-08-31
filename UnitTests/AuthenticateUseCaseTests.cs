﻿using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.Authenticate;
using Core.Application.UseCases;
using FluentAssertions;
using UnitTests.Services;
using UnitTests.UseCases.Authenticate;
using WebApi.UseCases.Authenticate;
using Xunit;

namespace UnitTests
{
    public class AuthenticateUseCaseTests
    {
        [Fact]
        public async Task AuthenticateUseCase_InvalidUserName_ShouldReturnError() 
        {
            // Arrange
            var userService = new FakeInvalidUserNameUserService();
            var presenter = new FakeAuthenticateOutputHandler();

            var sut = new AuthenticateUseCase(presenter, userService);

            var input = new AuthenticationInput("username", "password");

            // Act
            await sut.Execute(input);

            // Assert
            presenter.ErrorMessage
                .Should()
                .NotBeNull();

            presenter.ViewModel
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task AuthenticateUseCase_InvalidPassword_ShouldReturnError()
        {
            // Arrange
            var userService = new FakeInvalidPasswordUserService();
            var presenter = new FakeAuthenticateOutputHandler();

            var sut = new AuthenticateUseCase(presenter, userService);

            var input = new AuthenticationInput("username", "password");

            // Act
            await sut.Execute(input);

            // Assert
            presenter.ErrorMessage
                .Should()
                .NotBeNull();

            presenter.ViewModel
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task AuthenticateUseCase_ValidInput_ShouldReturnTheUser()
        {
            // Arrange
            var userService = new FakeUserService();
            var presenter = new FakeAuthenticateOutputHandler();

            var sut = new AuthenticateUseCase(presenter, userService);

            var input = new AuthenticationInput("username", "password");

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
