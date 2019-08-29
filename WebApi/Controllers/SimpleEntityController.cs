using System;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Application.Boundaries.UseCases.GetById;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.GetAll;
using WebApi.UseCases.GetById;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleEntitiesController : ControllerBase
    {
        private readonly GetAllOutputHandler _presenter;
        private readonly GetByIdOutputHandler _getByIdPresenter;
        private readonly IGetAllUseCase _useCase;
        private readonly IGetByIdUseCase _getByIdUseCase;

        public SimpleEntitiesController(
            IGetAllUseCase useCase, 
            IGetByIdUseCase getByIdUseCase,
            GetAllOutputHandler presenter,
            GetByIdOutputHandler getByIdPresenter)
        {
            _useCase = useCase;
            _getByIdUseCase = getByIdUseCase;
            _presenter = presenter;
            _getByIdPresenter = getByIdPresenter;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            _useCase.Execute();

            return _presenter.ViewModel;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _getByIdUseCase.Execute(id);

            return _getByIdPresenter.ViewModel;
        }
    }
}
