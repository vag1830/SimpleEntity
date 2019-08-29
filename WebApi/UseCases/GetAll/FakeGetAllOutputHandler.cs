using System.Collections.Generic;
using System.Linq;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Domain.Entities;

namespace WebApi.UseCases.GetAll
{
    public class FakeGetAllOutputHandler : IGetAllOutputHandler
    {
        public IList<SimpleEntityDto> ViewModel { get; private set; }

        public void Handle(IList<SimpleEntity> output)
        {
            ViewModel =  output
                .Select(item => new SimpleEntityDto
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();
        }

        public void Error()
        {
            throw new System.NotImplementedException();
        }
    }
}
