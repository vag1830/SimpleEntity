using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Boundaries.UseCases.GetById;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.UseCases;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetById
{
    public class GetByIdOutputHandler : IGetByIdOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Handle(SimpleEntity output)
        {
            var result = new SimpleEntityDto
            {
                Id = output.Id,
                Title = output.Title
            };

            ViewModel = new ObjectResult(result);
        }

        public void Error(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
