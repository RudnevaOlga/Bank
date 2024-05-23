using Domain.Entities;

namespace Application.Interfaces
{
   public interface ICardMenuService
   {
        Task<Card> WithdrawMoneyAsync(string number, decimal sum);

        Task<Card> DepositAsync(string number, decimal sum);

        Task<decimal> BalanceAsync(string number);
   }
}
