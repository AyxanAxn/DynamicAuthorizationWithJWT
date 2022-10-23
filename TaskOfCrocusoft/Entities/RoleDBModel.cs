using CrocusoftTask.Entities;

namespace TaskOfCrocusoft.Entities
{
    public class RoleDBModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public Guid PermissionId { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
