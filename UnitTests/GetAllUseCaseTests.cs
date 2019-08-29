using Core.Application.UseCases;
using Core.Infrastructure.Repositories;
using FluentAssertions;
using WebApi.UseCases.GetAll;
using Xunit;

namespace UnitTests
{
    public class GetAllUseCaseTests
    {
        [Fact]
        public void GetAllUseCase_NoItemsExist_ShouldReturnEmptyList()
        {
            // Arrange
            var repository = new FakeSimpleEntityEmptyListRepository();
            var presenter = new FakeGetAllOutputHandler();

            var sut = new GetAllUseCase(presenter, repository);

            // Act
            sut.Execute();

            // Assert
            presenter.ViewModel
                .Should()
                .BeEquivalentTo(repository.Data);
        }

        [Fact]
        public void GetAllUseCase_ItemsExist_ShouldReturnTheListOfItems()
        {
            // Arrange
            var repository = new FakeSimpleEntityRepository();
            var presenter = new FakeGetAllOutputHandler();

            var sut = new GetAllUseCase(presenter, repository);

            // Act
            
            sut.Execute();

            // Assert
            presenter.ViewModel
                .Should()
                .BeEquivalentTo(repository.Data);
        }
    }
}
