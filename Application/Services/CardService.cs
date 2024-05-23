using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private static int inputNumber = 0;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> CardNumberAsync(string number)
        {
            var result = await _cardRepository.GetCardAsync(number);

            if (result != null)
            {
                if (!result.block)
                {
                    return result;
                }

                throw new Exception("The card is blocked");
            }

            throw new Exception("The card does not exist");
        }

        public async Task<bool> CardPinAsync(string number, int pin)
        {
            var result = await _cardRepository.GetCardAsync(number);

            if (result.pin == pin)
            {
                return true;
            }

            else
            {
                inputNumber++;

                if (inputNumber == 4)
                {
                    result.block = true;

                    await _cardRepository.UpdateCardAsync(result);

                    throw new Exception("The card is blocked");
                }

                throw new Exception("Incorrect PIN-code, try again");
            }
        }
    }
}
