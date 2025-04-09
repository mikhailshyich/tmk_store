namespace TMKStore.DTOs
{
    public class ProductDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string StorageCondition { get; set; } = string.Empty;
        public double Cost { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double NutritionalValue { get; set; }
        public double EnergyValue { get; set; }
    }
}
