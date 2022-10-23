using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.PermossionCommands.RemovePermission
{
    public class RemovePermissionRequest:IRequest<RemovePermissionResponse>
    {
        public Guid Id { get; set; }
    }
}
