namespace Bank.CardSequrity
{
    public interface ISecurityRetrieve
    {
        void SetNumberCard(string number);

        string GetNumberCard();

        void LogOut();
    }
}
