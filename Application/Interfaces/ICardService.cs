using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICardService
    {
        Task<Card> CardNumberAsync(string number);

        Task<bool> CardPinAsync(string number, int pin);
    }
}
