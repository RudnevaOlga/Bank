namespace Domain.Entities
{
    public class Operation
    {
        public int id { get; set; }

        public DateTime time { get; set; }
        
        public decimal? sum { get; set; }

        public int cardId { get; set; }

        public Card card { get; set; }

        public int descriptionId { get; set; }
    }
}
