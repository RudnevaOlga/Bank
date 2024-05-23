using Application.Interfaces;
using Bank.CardSequrity;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank.Controllers
{
    public class CardMenuController : Controller
    {
        private readonly ICardMenuService _cardMenuService;
        private readonly ISecurityRetrieve _securityRetrieve;
        private readonly ICardRepository _cardRepository;

        public CardMenuController(ICardMenuService cardMenuService, ISecurityRetrieve securityRetrieve, ICardRepository cardRepository)
        {
            _cardMenuService = cardMenuService;
            _securityRetrieve = securityRetrieve;
            _cardRepository = cardRepository;
        }

        public IActionResult Menu() => View();

        [HttpGet("/Balance")]
        public async Task<IActionResult> Balance()
        {
            var cardCookie = _securityRetrieve.GetNumberCard();

            var res = await _cardRepository.GetCardAsync(cardCookie);

            var result = await _cardMenuService.BalanceAsync(cardCookie);

            return View("Balance", res);
        }

        [HttpGet(nameof(Widthdraw))]
        public IActionResult Widthdraw() => View("Widthdraw");

        [HttpPost(nameof(Widthdraw))]
        public async Task<IActionResult> Widthdraw(decimal sum)
        {
            var cardCookie = _securityRetrieve.GetNumberCard();
            
            var result = await _cardMenuService.WithdrawMoneyAsync(cardCookie, sum);

            return View("Menu");
        }

        public IActionResult Deposite() => View();

        [HttpPost(nameof(Deposit))]
        public async Task<IActionResult> Deposit(decimal sum)
        {
            var cardCookie = _securityRetrieve.GetNumberCard();

            var result = await _cardMenuService.DepositAsync(cardCookie, sum);

            return View("Menu");
        }
    }
}
