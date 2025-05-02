namespace TMKStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public Guid CartsGuid { get; set; }
    }
}
