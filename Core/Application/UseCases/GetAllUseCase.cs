using System.Threading.Tasks;
using Core.Application.Boundaries.UseCases.Authenticate;
using Core.Application.Boundaries.UseCases.GetAll;
using Core.Application.Persistence;

namespace Core.Application.UseCases
{
    public class GetAllUseCase : IGetAllUseCase
    {
        private ISimpleEntityRepository _repository;
        private IGetAllOutputHandler _outputHandler;

        public GetAllUseCase(IGetAllOutputHandler outputHandler, ISimpleEntityRepository repository)
        {
            _outputHandler = outputHandler;
            _repository = repository;
        }

        public async Task Execute()
        {
            var output = await _repository.GetAll();

            await _outputHandler.Handle(output);
        }
    }
}
