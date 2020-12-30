using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ArtWorkWithCategorySpecification : BaseSpecification<Artwork>
    {
        public ArtWorkWithCategorySpecification(ArtworkSpecParams specParams)
            : base(x => (
                (string.IsNullOrEmpty(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)) &&
                (!specParams.CategoryId.HasValue || x.CategoryId == specParams.CategoryId)
            ))
        {
            AddInclude(x => x.Category);
            AddOrderBy(x => x.Title);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            if(!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "dateAsc":
                        AddOrderByAscending(x => x.Date);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(x => x.Date);
                        break;
                    default:
                        AddOrderBy(x => x.Title);
                        break;
                }
            }
        }

        public ArtWorkWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}