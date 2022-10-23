using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TaskOfCrocusoft.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TaskOfCrocusoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;

        public BookController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _config = configuration;
        }

        [HttpGet("GetAll")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "CanGet")]

        public IActionResult GetBooks()
        {
            Book b = new();
            b.Author = "Salam";
            return Ok(b.Author);
        }


        [HttpPost("CreateItem")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "CanCreate")]
        public async Task<IActionResult> CreateBooks()
        {
            return Ok("I can create!");
        }
    }
}
