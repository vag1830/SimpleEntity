using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Boundaries.UseCases.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetAll
{
    public class GetAllOutputHandler : IGetAllOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Handle(IList<SimpleEntity> output)
        {
            var result = output
                .Select(item => new SimpleEntityDto
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();

            ViewModel = new ObjectResult(result);
        }

        public void Error(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
