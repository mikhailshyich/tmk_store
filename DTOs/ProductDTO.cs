using System.ComponentModel.DataAnnotations;

namespace TMKStore.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Weight { get; set; }
        [Required]
        public string StorageCondition { get; set; } = string.Empty;
        [Required, Range(1.0, 1000.0)]
        public decimal Price { get; set; }
        public int Count { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double NutritionalValue { get; set; }
        public double EnergyValue { get; set; }
        public DateTime DateTimeAdded { get; set; } = DateTime.Now;
    }
}
