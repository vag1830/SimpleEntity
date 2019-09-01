using System;
using System.Threading.Tasks;
using Application.Boundaries.Persistence;
using Application.Boundaries.UseCases.GetById;

namespace Application.UseCases
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private ISimpleEntityRepository _repository;
        private IGetByIdOutputHandler _outputHandler;

        public GetByIdUseCase(IGetByIdOutputHandler outputHandler, ISimpleEntityRepository repository)
        {
            _outputHandler = outputHandler;
            _repository = repository;
        }

        public async Task Execute(Guid id)
        {
            var output = await _repository.GetById(id);

            if (output == null)
            {
                await _outputHandler.Error($"There is no item with id: {id.ToString()}");
            }
            else
            {
                await _outputHandler.Handle(output);
            }
        }
    }
}
