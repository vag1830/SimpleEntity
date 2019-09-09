using System.Collections.Generic;
using System.Linq;
using Application.Boundaries.UseCases.GetAll;
using Domain.Entities;
using WebApi.UseCases.GetAll;

namespace UnitTests.UseCases.GetAll
{
    public class FakeGetAllOutputHandler : IGetAllOutputHandler
    {
        public IList<SimpleEntityDto> ViewModel { get; private set; }

        public void Handle(IList<SimpleEntity> output)
        {
            ViewModel = output
                .Select(item => new SimpleEntityDto
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();
        }

        public void Error(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
