using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Entities.Base;

namespace CrocusoftTask.Entities
{
    public class User : BaseComponent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<UserRoles>? UserRoles { get; set; }
    }
}