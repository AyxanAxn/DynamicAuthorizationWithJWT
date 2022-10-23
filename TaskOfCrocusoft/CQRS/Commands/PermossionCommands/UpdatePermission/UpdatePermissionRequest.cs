using CrocusoftTask.Entities;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.PermossionCommands.UpdatePermission
{
    public class UpdatePermissionRequest:IRequest<UpdatePermissionResponse>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Title { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}