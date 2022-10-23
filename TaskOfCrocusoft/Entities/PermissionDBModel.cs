namespace TaskOfCrocusoft.Entities
{
    public class PermissionDBModel
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string PermissionName { get; set; }
        public RoleDBModel RoleDBModel { get; set; }
    }
}
