using CrocusoftTask.Entities;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Queries.RoleQueries.GetAllRoles
{
    public class GetAllRolesQueryRequest : IRequest<GetAllRolesQueryResponse>
    {
    }
}