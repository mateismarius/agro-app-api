using API.Errors;
using Infrastructure.AppContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationContext _context;

        public BuggyController(ApplicationContext context)
        {
            _context = context;
        }

        // Returns a test string only if the user is authenticated.
        [Authorize]
        [HttpGet("testauth")]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        // Returns a 404 not found response with an error message.
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products?.Find(42);

            if (thing == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }

        // Returns a 500 internal server error response with an error message.
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            try
            {
                var thing = _context.Products?.Find(42);

                if (thing == null)
                    throw new Exception("server error");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        // Returns a 400 bad request response with an error message.
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        // This method intentionally doesn't do anything because is not implemented yet and will always return OK. 
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }

}
