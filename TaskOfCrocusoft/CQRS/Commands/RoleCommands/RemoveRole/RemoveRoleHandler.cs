using CrocusoftTask.Repositories.IRepository.IRoleRepository;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.RoleCommands.RemoveRole
{
    public class RemoveRoleHandler : IRequestHandler<RemoveRoleRequest, RemoveRoleResponse>
    {
        private readonly IRoleWriteRepository _roleWriteRepository;
        public RemoveRoleHandler(
            IRoleWriteRepository roleWriteRepository)
        {
            _roleWriteRepository=roleWriteRepository;
        }

        public async Task<RemoveRoleResponse> Handle(RemoveRoleRequest request, CancellationToken cancellationToken)
        {
            await _roleWriteRepository.RemoveAsync((request.Id).ToString());
            await _roleWriteRepository.SaveAsync();
            return new();            
        }
    }
}
