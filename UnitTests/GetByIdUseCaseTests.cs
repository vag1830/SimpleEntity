using System;
using System.Threading.Tasks;
using Core.Application.UseCases;
using FluentAssertions;
using UnitTests.Persistense;
using UnitTests.UseCases.GetById;
using Xunit;

namespace UnitTests
{
    public class GetByIdUseCaseTests
    {
        [Fact]
        public async Task GetByIdUseCase_ItemDoesNotExist_ShouldReturnErrorMessage()
        {
            // Arrange
            var repository = new FakeSimpleEntityEmptyListRepository();
            var presenter = new FakeGetByIdOutputHandler();

            var sut = new GetByIdUseCase(presenter, repository);

            // Act
            await sut.Execute(Guid.NewGuid());

            // Assert
            presenter.ErrorMessage
                .Should()
                .NotBeNull();

            presenter.ViewModel
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetByIdUseCase_ItemExists_ShouldReturnTheItem()
        {
            // Arrange
            var repository = new FakeSimpleEntityRepository();
            var presenter = new FakeGetByIdOutputHandler();

            var sut = new GetByIdUseCase(presenter, repository);

            // Act
            await sut.Execute(Guid.NewGuid());

            // Assert
            presenter.ViewModel
                .Should()
                .BeEquivalentTo(repository.Item);
        }
    }
}
