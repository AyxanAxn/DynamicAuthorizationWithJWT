using CrocusoftTask.Repositories.IRepository.IPermissionRepository;
using CrocusoftTask.Repositories.IRepository.IRoleRepository;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.PermossionCommands.UpdatePermission
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionRequest, UpdatePermissionResponse>
    {
        private readonly IPermissionReadRepository _permissionReadRepository;
        private readonly IPermissionWriteRepository _permissionWriteRepository;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IRoleReadRepository _roleReadRepository;
        public UpdatePermissionHandler(
            IPermissionWriteRepository permissionWriteRepository,
            IRoleReadRepository roleReadRepository,
            IPermissionReadRepository permissionReadRepository,
            IRoleWriteRepository roleWriteRepository
            )
        {
            _permissionWriteRepository = permissionWriteRepository;
            _roleReadRepository = roleReadRepository;
            _roleWriteRepository = roleWriteRepository;
            _permissionReadRepository = permissionReadRepository;
        }

        public async Task<UpdatePermissionResponse> Handle(UpdatePermissionRequest request, CancellationToken cancellationToken)
        {
            var currentPermission = await _permissionReadRepository.GetByIdAsync((request.Id).ToString());
            currentPermission.Title = request.Title;
            

            _permissionWriteRepository.Update(currentPermission);
            return new();

        }
    }
}
