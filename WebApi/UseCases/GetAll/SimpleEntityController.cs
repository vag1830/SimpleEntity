﻿using System;
using System.Threading.Tasks;
using Application.Boundaries.UseCases.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;

namespace WebApi.UseCases.GetAll
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleEntitiesController : ControllerBase
    {
        private readonly GetAllOutputHandler _presenter;
        private readonly IGetAllUseCase _useCase;

        public SimpleEntitiesController(IGetAllUseCase useCase, GetAllOutputHandler presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            await _useCase.Execute();

            return _presenter.ViewModel;
        }
    }
}
