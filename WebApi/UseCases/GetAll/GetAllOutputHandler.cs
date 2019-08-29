﻿using System.Collections.Generic;
using System.Linq;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.GetAll
{
    public class GetAllOutputHandler : IGetAllOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Handle(IList<SimpleEntity> output)
        {
            var result = output.Select(item => new SimpleEntityDto
            {
                Id = item.Id,
                Title = item.Title
            });

            ViewModel = new ObjectResult(result);
        }

        public void Error()
        {
            throw new System.NotImplementedException();
        }
    }
}