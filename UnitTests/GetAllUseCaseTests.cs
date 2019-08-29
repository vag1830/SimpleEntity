using System.Threading.Tasks;
using Core.Application.UseCases;
using FluentAssertions;
using Infrastucture.Repositories;
using WebApi.UseCases.GetAll;
using Xunit;

namespace UnitTests
{
    public class GetAllUseCaseTests
    {
        [Fact]
        public async Task GetAllUseCase_NoItemsExist_ShouldReturnEmptyList()
        {
            // Arrange
            var repository = new FakeSimpleEntityEmptyListRepository();
            var presenter = new FakeGetAllOutputHandler();

            var sut = new GetAllUseCase(presenter, repository);

            // Act
            await sut.Execute();

            // Assert
            presenter.ViewModel
                .Should()
                .BeEquivalentTo(repository.Data);
        }

        [Fact]
        public async Task GetAllUseCase_ItemsExist_ShouldReturnTheListOfItems()
        {
            // Arrange
            var repository = new FakeSimpleEntityRepository();
            var presenter = new FakeGetAllOutputHandler();

            var sut = new GetAllUseCase(presenter, repository);

            // Act
            
            await sut.Execute();

            // Assert
            presenter.ViewModel
                .Should()
                .BeEquivalentTo(repository.Data);
        }
    }
}
