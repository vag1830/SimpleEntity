using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.GetById;
using Core.Domain.Entities;
using WebApi.UseCases.GetById;

namespace UnitTests.UseCases.GetById
{
    public class FakeGetByIdOutputHandler : IGetByIdOutputHandler
    {
        public SimpleEntityDto ViewModel { get; private set; }
        public string ErrorMessage { get; private set; }

        public Task Handle(SimpleEntity output)
        {
            ViewModel = new SimpleEntityDto
            {
                Id = output.Id,
                Title = output.Title
            };

            return Task.CompletedTask;
        }

        public Task Error(string message)
        {
            ErrorMessage = message;

            return Task.CompletedTask;
        }
    }
}
