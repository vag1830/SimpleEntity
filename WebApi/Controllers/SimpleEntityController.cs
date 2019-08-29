using Core.Application.Boundaries.UseCases.GetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.GetAll;

namespace WebApi.Controllers
{
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
        public IActionResult Get()
        {
            _useCase.Execute();

            return _presenter.ViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
