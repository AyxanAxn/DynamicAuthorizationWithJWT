using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskOfCrocusoft.CQRS.Queries.BookQueries.GetAllBooks;
using TaskOfCrocusoft.CQRS.Commands.BookCommands.CreateBookCommand;
using TaskOfCrocusoft.CQRS.Commands.BookCommands.DeleteBookCommand;
using TaskOfCrocusoft.CQRS.Commands.BookCommands.EditBookCommand;

namespace TaskOfCrocusoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "CanGet")]
        public async Task<IActionResult> GetBooks([FromQuery] GetAllBookQueriesRequest request)
        {
            var response = _mediator.Send(request);

            return Ok(response);
        }
        [HttpPost("CreateBook")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "CanCreate")]
        //[AllowAnonymous]
        public async Task<IActionResult> CreateBooks(CreateBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("Remove")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "CanDelete")]
        //[AllowAnonymous]
        public async Task<IActionResult> RemoveBooks(DeleteBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "CanUpdate")]
        //[AllowAnonymous]
        public async Task<IActionResult> UpdateBooks(EditBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}