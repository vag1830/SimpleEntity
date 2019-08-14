using Core.Application.UseCases;
using Core.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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

            var outputHandler = new GetAllOutputHandler();

            var sut = new GetAllUseCase(outputHandler, repository);

            // Act
            sut.Execute();

            // Assert
            outputHandler.ViewModel
                .As<ObjectResult<I>>       
            }

        [Fact]
        public void GetAllUseCase_ItemsExist_ShouldReturnTheListOfItems()
        {
            // Arrange
            var repository = new FakeSimpleEntityRepository();
            var sut = new GetAllUseCase(repository);

            // Act
            var output = sut.Execute();

            // Assert
            output
                .Should()
                .BeEquivalentTo(repository.Data);
        }
    }
}
