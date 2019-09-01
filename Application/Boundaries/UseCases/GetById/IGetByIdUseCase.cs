using System;
using System.Threading.Tasks;

namespace Application.Boundaries.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Task Execute(Guid id);
    }
}
