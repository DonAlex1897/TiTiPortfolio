using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly PortfolioContext _context;
        public BuggyController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFountRequset()
        {
            if (_context.Artworks.Find(42) == null)
                return NotFound(new ApiResponse(404));
            return Ok();
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _context.Artworks.Find(42);
            var productString = product.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}