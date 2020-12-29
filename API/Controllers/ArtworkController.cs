using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ArtworkController : BaseApiController
    {
        public Task<ActionResult<ICollection<Artwork>>> GetArtworks()
        {
            return null;
        }
    }
}