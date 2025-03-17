namespace TMKStore.DTOs
{
    public class GoodsDTO
    {
        string Title { get; set; } = string.Empty;
        string Weight { get; set; } = string.Empty;

        public GoodsDTO(string title, string weight) 
        {
            Title = title;
            Weight = weight;
        }
    }
}
