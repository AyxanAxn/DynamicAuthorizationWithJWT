using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.RoleCommands.RemoveRole
{
    public class RemoveRoleRequest:IRequest<RemoveRoleResponse>
    {
        public Guid Id { get; set; }
    }
}