using System.ComponentModel.DataAnnotations;

namespace TMKStore.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Subtitle { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Weight { get; set; }
        [Required]
        public string StorageCondition { get; set; } = string.Empty;
        [Required, Range(1.0, 1000.0)]
        public decimal Price { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public double Protein { get; set; }
        [Required]
        public double Fats { get; set; }
        [Required]
        public double NutritionalValue { get; set; }
        [Required]
        public double EnergyValue { get; set; }
        [Required]
        public DateTime DateTimeAdded { get; set; }
    }
}
