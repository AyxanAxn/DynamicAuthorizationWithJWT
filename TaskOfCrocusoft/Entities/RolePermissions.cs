using CrocusoftTask.Entities;

namespace TaskOfCrocusoft.Entities
{
    public class RolePermissions
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
