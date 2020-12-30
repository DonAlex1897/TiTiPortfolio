using API.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ArtworkUrlResolver : IValueResolver<Artwork, ArtworkToReturnDTO, string>
    {
        private readonly IConfiguration _config;
        public ArtworkUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Artwork source, ArtworkToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl)){
                return _config["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}