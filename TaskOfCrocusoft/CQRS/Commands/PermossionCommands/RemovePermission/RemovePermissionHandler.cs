using CrocusoftTask.Repositories.IRepository.IPermissionRepository;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.PermossionCommands.RemovePermission
{
    public class RemovePermissionHandler:IRequestHandler<RemovePermissionRequest, RemovePermissionResponse>
    {
        private readonly IPermissionWriteRepository _permissionWriteRepository;
        public RemovePermissionHandler(
            IPermissionWriteRepository permissionWriteRepository
            )
        {
            _permissionWriteRepository = permissionWriteRepository;
        }

        public async Task<RemovePermissionResponse> Handle(RemovePermissionRequest request, CancellationToken cancellationToken)
        {
            await _permissionWriteRepository.RemoveAsync((request.Id).ToString());
            await _permissionWriteRepository.SaveAsync();
            return new();
        }
    }
}