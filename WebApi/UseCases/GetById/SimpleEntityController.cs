﻿using System;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Application.Boundaries.UseCases.GetById;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetById
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleEntitiesController : ControllerBase
    {
        private readonly GetByIdOutputHandler _presenter;
        private readonly IGetByIdUseCase _useCase;

        public SimpleEntitiesController(IGetByIdUseCase useCase, GetByIdOutputHandler presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _useCase.Execute(id);

            return _presenter.ViewModel;
        }
    }
}
