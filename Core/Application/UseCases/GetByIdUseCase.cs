using System;
using Core.Application.Boundaries.UseCases.GetById;
using Core.Application.Persistence;

namespace Core.Application.UseCases
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

        public void Execute(Guid id)
        {
            var output = _repository.GetById(id);

            if (output == null)
            {
                _outputHandler.Error($"There is no item with id: {id.ToString()}");
            }
            else 
            {
                _outputHandler.Handle(output);
            }
        }
    }
}
