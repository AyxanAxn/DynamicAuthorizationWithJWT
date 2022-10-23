using CrocusoftTask.Entities;

namespace TaskOfCrocusoft.CQRS.Queries.RoleQueries.GetAllRoles
{
    public class GetAllRolesQueryResponse
    {
        public ICollection<Role> RoleResponse { get; set; }
        public string Message { get; set; }
    }
}
