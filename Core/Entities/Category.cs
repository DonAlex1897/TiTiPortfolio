using System.Collections.Generic;

namespace Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Artwork> Artwork { get; set; }
    }
}