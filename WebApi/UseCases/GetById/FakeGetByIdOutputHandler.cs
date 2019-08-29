using System.Collections.Generic;
using System.Linq;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Application.Boundaries.UseCases.GetById;
using Core.Domain.Entities;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetAll
{
    public class FakeGetByIdOutputHandler : IGetByIdOutputHandler
    {
        public SimpleEntityDto ViewModel { get; private set; }
        public string ErrorMessage { get; private set; }

        public void Handle(SimpleEntity output)
        {
            ViewModel =  new SimpleEntityDto
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
