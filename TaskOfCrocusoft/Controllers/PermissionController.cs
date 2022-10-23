using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOfCrocusoft.CQRS.Commands.PermossionCommands.CreatePermission;

namespace TaskOfCrocusoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private IMediator _mediatR;
        public PermissionController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissionsForRole(CreatePermissionRequest request)
        {
            var response =await _mediatR.Send(request);
            return Ok(response);
        }


    }
}
