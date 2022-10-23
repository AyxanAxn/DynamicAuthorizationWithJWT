using CrocusoftTask.Entities;

namespace TaskOfCrocusoft.Entities
{
    public class UserRoles
    {
        public Guid id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
