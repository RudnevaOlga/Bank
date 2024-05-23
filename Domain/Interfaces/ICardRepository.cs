using Domain.Entities;

namespace Domain.Interfaces
{
   public interface ICardRepository
   {
        Task<Card> GetCardAsync(string number);

        Task UpdateCardAsync(Card card);
   }
}
