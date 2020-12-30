using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ArtworkController : BaseApiController
    {
        private readonly IGenericRepository<Artwork> _artworkRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public ArtworkController(IGenericRepository<Artwork> artworkRepo,
                                 IGenericRepository<Category> categoryRepo,
                                 IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _artworkRepo = artworkRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ArtworkToReturnDTO>>> GetArtworks([FromQuery]ArtworkSpecParams artworkSpec)
        {
            var spec = new ArtWorkWithCategorySpecification(artworkSpec);
            var countSpec = new ArtworkWithFiltersForCountSpecification(artworkSpec);
            var totalItems = await _artworkRepo.CountAsync(countSpec);
            var products = await _artworkRepo.ListWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Artwork>, IReadOnlyList<ArtworkToReturnDTO>>(products);


            return Ok(new Pagination<ArtworkToReturnDTO>(artworkSpec.PageIndex, artworkSpec.PageSize, totalItems, data));
        }
    }
}