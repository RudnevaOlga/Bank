using Domain.Entities;
using System;

namespace Application.Interfaces
{
    public interface IOperationService
    {
        Task OperationAsync(int cardId, int decriptionId, decimal? sum = null);
    }
}
