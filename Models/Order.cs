namespace TMKStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UniqueGuid { get; set; }

        public virtual Product Product { get; set; }
    }
}
