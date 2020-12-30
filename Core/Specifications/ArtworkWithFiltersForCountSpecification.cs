using Core.Entities;

namespace Core.Specifications
{
    public class ArtworkWithFiltersForCountSpecification : BaseSpecification<Artwork>
    {
        public ArtworkWithFiltersForCountSpecification(ArtworkSpecParams specParams)
            : base(x => (
                (string.IsNullOrEmpty(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)) &&
                (!specParams.CategoryId.HasValue || x.CategoryId == specParams.CategoryId)
            ))
        {
        }
    }
}