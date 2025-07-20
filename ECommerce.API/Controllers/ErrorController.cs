using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {

        [HttpGet("not-found")]
        public IActionResult NotFoundError()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public IActionResult BadRequestError()
        {
            return BadRequest();
        }

        [HttpGet("unauthorized")]
        public IActionResult UnAuthorizedError()
        {
            return Unauthorized();
        }


        [HttpGet("validation-error")]
        public IActionResult ValidationError()
        {
            ModelState.AddModelError("Error", "Validation error occurred.");
            return ValidationProblem();
        }
        [HttpGet("server-error")]
        public IActionResult ServerError()
        {
           throw new Exception("Server error occurred.");
        }
    }
}
