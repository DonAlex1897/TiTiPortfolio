namespace API.DTOs
{
    public class ArtworkToReturnDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}