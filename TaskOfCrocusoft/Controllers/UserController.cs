using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOfCrocusoft.CQRS.Commands.UserCommands.CreateUser;
using TaskOfCrocusoft.CQRS.Queries.UserQuerues.LogInUser;

namespace TaskOfCrocusoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;

        public UserController(IConfiguration config, IMediator mediator)
        {
            _config = config;
            _mediator = mediator;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInUserQueryRequest request)
        {

            LogInUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
