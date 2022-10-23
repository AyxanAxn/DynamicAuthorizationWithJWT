using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.PermossionCommands.CreatePermission
{
    public class CreatePermissionRequest : IRequest<CreatePermissionResponse>
    {
        public string PermissionName { get; set; }
        public string RoleName { get; set; }
    }
}
