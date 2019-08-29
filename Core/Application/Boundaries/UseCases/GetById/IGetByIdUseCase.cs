using System;
using System.Threading.Tasks;

namespace Core.Application.Boundaries.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Task Execute(Guid id);
    }
}
