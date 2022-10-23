using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.RoleCommands.CreateRole
{
    public class CreateRoleRequest : IRequest<CreateRoleResponse>
    {
        public Guid UserId { get; set; }
        public string RoleName { get; set; }
        public ICollection<string> PermissionTypes { get; set; }
    }
}