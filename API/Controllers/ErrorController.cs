using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly DataContext _context;
        public ErrorController(DataContext context)
        {
            this._context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret() {
            return "secret text.";
        }

        [HttpGet("not-found")]
        public IActionResult GetNotFound() {
            return NotFound();
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError() {
           var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString();
            return Ok(thingToReturn);
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest() {
            return BadRequest("this was not a good request.");
        }
    }
}