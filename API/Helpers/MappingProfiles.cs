using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Artwork, ArtworkToReturnDTO>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Title))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<ArtworkUrlResolver>());
        }
    }
}