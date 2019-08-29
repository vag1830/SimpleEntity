using System;
using Core.Application.UseCases;
using FluentAssertions;
using Infrastucture.Repositories;
using WebApi.UseCases.GetAll;
using Xunit;

namespace UnitTests
{
    public class GetByIdUseCaseTests
    {
        [Fact]
        public void GetByIdUseCase_ItemDoesNotExist_ShouldReturnErrorMessage()
        {
            // Arrange
            var repository = new FakeSimpleEntityEmptyListRepository();
            var presenter = new FakeGetByIdOutputHandler();

            var sut = new GetByIdUseCase(presenter, repository);

            // Act
            sut.Execute(Guid.NewGuid());

            // Assert
            presenter.ErrorMessage
                .Should()
                .NotBeNull();

            presenter.ViewModel
                .Should()
                .BeNull();
        }

        [Fact]
        public void GetByIdUseCase_ItemExists_ShouldReturnTheItem()
        {
            // Arrange
            var repository = new FakeSimpleEntityRepository();
            var presenter = new FakeGetByIdOutputHandler();

            var sut = new GetByIdUseCase(presenter, repository);

            // Act
            sut.Execute(Guid.NewGuid());

            // Assert
            presenter.ViewModel
                .Should()
                .BeEquivalentTo(repository.Item);
        }
    }
}
