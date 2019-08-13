using System.Collections.Generic;
using Core.Domain.Entities;
using Core.Infrastructure.Repositories;

namespace Core.Application.UseCases
{
    public class GetAllUseCase
    {
        private FakeEntitiesRepository _repository;

        public GetAllUseCase(FakeEntitiesRepository repository)
        {
            _repository = repository;
        }

        public IList<SimpleEntity> Execute()
        {
            return _repository.GetAll();
        }
    }
}
