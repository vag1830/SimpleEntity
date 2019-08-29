using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetAll
{
    public class GetAllOutputHandler : IGetAllOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public Task Handle(IList<SimpleEntity> output)
        {
            var result = output
                .Select(item => new SimpleEntityDto
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();

            ViewModel = new ObjectResult(result);

            return Task.CompletedTask;
        }

        public Task Error(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
