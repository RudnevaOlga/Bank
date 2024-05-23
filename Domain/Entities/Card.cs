namespace Domain.Entities
{
    public class Card
    {
        public int id { get; set; }

        public string number { get; set; }

        public decimal balance { get; set; }

        public int pin { get; set; }

        public bool block { get; set; }                              
    }
}
