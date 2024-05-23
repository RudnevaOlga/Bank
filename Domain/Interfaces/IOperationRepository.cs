using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOperationRepository
    {
        Task AddOperationAsync(Operation operation);
    }
}
