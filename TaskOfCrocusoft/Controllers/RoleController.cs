using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOfCrocusoft.CQRS.Commands.RoleCommands.CreateRole;

namespace TaskOfCrocusoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private IMediator _mediatR;
        public RoleController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("CreateRole")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            var response = _mediatR.Send(request);
            return Ok(response);
        }

    }
}