using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IArtworkRepository
    {
        Task<IEnumerable<Artwork>> GetArtworks();

        Task<Artwork> GetArtworkById(int id);

        Task<IEnumerable<Category>> GetCategories(int id);

        Task<Category> GetCategoryById(int id);
    }
}