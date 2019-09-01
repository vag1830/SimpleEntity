using System.Threading.Tasks;
using Application.Boundaries.Persistence;
using Application.Boundaries.UseCases.GetAll;

namespace Application.UseCases
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
