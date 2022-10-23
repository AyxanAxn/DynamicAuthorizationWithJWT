using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Entities.Base;

namespace CrocusoftTask.Entities
{
    public class Role : BaseComponent
    {
        public string RoleName { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<RolePermissions> RolePermissions { get; set; }
    }
}