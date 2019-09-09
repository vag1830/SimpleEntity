using Application.Boundaries.UseCases.GetById;
using Domain.Entities;
using WebApi.UseCases.GetById;

namespace UnitTests.UseCases.GetById
{
    public class FakeGetByIdOutputHandler : IGetByIdOutputHandler
    {
        public SimpleEntityDto ViewModel { get; private set; }
        public string ErrorMessage { get; private set; }

        public void Handle(SimpleEntity output)
        {
            ViewModel = new SimpleEntityDto
            {
                Id = output.Id,
                Title = output.Title
            };
        }

        public void Error(string message)
        {
            ErrorMessage = message;
        }
    }
}
