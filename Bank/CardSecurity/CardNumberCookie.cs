using Domain.Interfaces;

namespace Bank.CardSequrity
{
    public class CardNumberCookie : ISecurityRetrieve
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private const string sessionKey = "card number";

        public CardNumberCookie(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void SetNumberCard(string number)
        {
            _contextAccessor.HttpContext.Session.SetString(sessionKey, number);
        }

        public string GetNumberCard()
        {
            return _contextAccessor.HttpContext.Session.GetString(sessionKey);
        }

        public void LogOut()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }
    }
}
