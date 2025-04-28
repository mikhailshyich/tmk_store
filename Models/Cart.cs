using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TMKStore.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public int Count { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Product Product { get; set; }
    }
}
