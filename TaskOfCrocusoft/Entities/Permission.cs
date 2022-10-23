using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Entities.Base;

namespace CrocusoftTask.Entities
{
    public class Permission : BaseComponent
    {
        public string Title { get; set; }
        public ICollection<RolePermissions> RolePermissions { get; set; }
    }
}