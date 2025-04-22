using System.ComponentModel.DataAnnotations;

namespace TMKStore.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Наименование продукта не может быть пустым")]
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Вес продукта не может быть пустым")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Условия хранения продукта не могут быть пустыми")]
        public string StorageCondition { get; set; } = string.Empty;
        [Required(ErrorMessage = "Цена продукта не может быть пустой")]
        public decimal Price { get; set; }
        public int Count { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double NutritionalValue { get; set; }
        public double EnergyValue { get; set; }
        public string? SrcImageProduct { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}
