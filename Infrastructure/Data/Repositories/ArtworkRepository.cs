using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class ArtworkRepository : IArtworkRepository
    {
        private readonly PortfolioContext _context;
        public ArtworkRepository(PortfolioContext context)
        {
            _context = context;
        }

        public Task<Artwork> GetArtworkById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Artwork>> GetArtworks()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}