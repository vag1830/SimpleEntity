using System.Collections.Generic;
using Core.Application.UseCases;
using Core.Domain.Entities;
using Core.Infrastructure.Repositories;
using Xunit;

namespace UnitTests
{
    public class GetAllUseCaseTests
    {
        [Fact]
        public void GetAllUseCase_NoItemsExist_ShouldReturnEmptyList()
        {
            var repository = new FakeEntitiesRepository();

            var sut = new GetAllUseCase(repository);

            IList<SimpleEntity> output = sut.Execute();

            Assert.Empty(output);
        }
    }
}
