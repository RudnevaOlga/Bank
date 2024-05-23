using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public async Task OperationAsync(int cardID, int descriptionId, decimal? sum = null)
        {
            var newOperation = new Operation
            {
                cardId = cardID,

                descriptionId = descriptionId,

                time = DateTime.Now.Date.ToUniversalTime(),

                sum = sum
            };

            await _operationRepository.AddOperationAsync(newOperation);
        }

    }
}
