using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Domain.Entities;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetAll
{
    public class FakeGetAllOutputHandler : IGetAllOutputHandler
    {
        public IList<SimpleEntityDto> ViewModel { get; private set; }

        public Task Handle(IList<SimpleEntity> output)
        {
            ViewModel =  output
                .Select(item => new SimpleEntityDto
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();

            return Task.CompletedTask;
        }

        public Task Error(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
