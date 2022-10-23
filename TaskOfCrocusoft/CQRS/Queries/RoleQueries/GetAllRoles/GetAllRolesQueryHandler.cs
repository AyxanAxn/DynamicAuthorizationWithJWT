using CrocusoftTask.Repositories.IRepository.IRoleRepository;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Queries.RoleQueries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
    {
        private readonly IRoleReadRepository _roleReadRepository;
        public GetAllRolesQueryHandler(IRoleReadRepository roleReadRepository)
        {
            _roleReadRepository = roleReadRepository;
        }

        public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var allRoles = _roleReadRepository.GetAll().ToList();


            return new() { RoleResponse = allRoles };



        }
    }
}
