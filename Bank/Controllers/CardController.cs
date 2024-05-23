using Application.Interfaces;
using Bank.CardSequrity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        private readonly ISecurityRetrieve _securityRetrieve;

        public CardController(ICardService cardService, ISecurityRetrieve securityRetrieve)
        {
            _cardService = cardService;
            _securityRetrieve = securityRetrieve;
        }

        public IActionResult Login() => View();

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(string number)
        {
            var card = await _cardService.CardNumberAsync(number);

            _securityRetrieve.SetNumberCard(card.number);

            return View("Password");
        }

        public IActionResult Password() => View();

        [HttpPost(nameof(Password))]
        public async Task<IActionResult> Password(int pin)
        {
            var cardCookie = _securityRetrieve.GetNumberCard();

            await _cardService.CardPinAsync(cardCookie, pin);

            return RedirectToAction("Menu", "CardMenu");
        }
    }
}
