using System;

namespace Core.Application.Boundaries.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        void Execute(Guid id);
    }
}
