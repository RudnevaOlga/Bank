using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CardMenuService : ICardMenuService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IOperationService _operationService;

        public CardMenuService(ICardRepository cardRepository, IOperationService operationService)
        {
            _cardRepository = cardRepository;
            _operationService = operationService;
        }
        public async Task<Card> WithdrawMoneyAsync(string number, decimal sum)
        {
            var result = await _cardRepository.GetCardAsync(number);

            if (sum <= result.balance)
            {
                result.balance -= sum;

                await _cardRepository.UpdateCardAsync(result);

                await _operationService.OperationAsync(result.id, (int)CodeOperation.withdrawMoney, sum);

                return result;
            }

            throw new Exception("The withdrawal amount exceeds the set limit");
        }

        public async Task<Card> DepositAsync(string number, decimal sum)
        {
            var result = await _cardRepository.GetCardAsync(number);

            if (sum > 0)
            {
                result.balance += sum;

                await _cardRepository.UpdateCardAsync(result);

                await _operationService.OperationAsync(result.id, (int)CodeOperation.deposite, sum);

                return result;
            }

            throw new Exception("The amount must be greater than 0");
        }

        public async Task<decimal> BalanceAsync(string number)
        {
            var result = await _cardRepository.GetCardAsync(number);

            await _operationService.OperationAsync(result.id, (int)CodeOperation.balance);

            return result.balance;
        }
    }
}
