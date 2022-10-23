using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IPermissionRepository;
using CrocusoftTask.Repositories.IRepository.IRoleRepository;
using MediatR;
using TaskOfCrocusoft.Entities;

namespace TaskOfCrocusoft.CQRS.Commands.PermossionCommands.CreatePermission
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermissionRequest, CreatePermissionResponse>
    {

        private readonly IPermissionWriteRepository _permissionWriteRepository;
        private readonly IPermissionReadRepository _permissionReadRepository;
        private readonly IRoleReadRepository _roleReadRepository;
        public CreatePermissionHandler(
            IPermissionWriteRepository permissionWriteRepository,
            IPermissionReadRepository permissionReadRepository,
            IRoleReadRepository roleReadRepository
            )
        {
            _permissionWriteRepository = permissionWriteRepository;
            _permissionReadRepository = permissionReadRepository;
            _roleReadRepository = roleReadRepository;
        }
        public async Task<CreatePermissionResponse> Handle(CreatePermissionRequest request, CancellationToken cancellationToken)
        {
            Permission permission = new();
            var findPermissionByName = _permissionReadRepository.GetWhere(p => p.Title == request.PermissionName).ToList();
            var allRoles = _roleReadRepository.GetWhere(r => r.RoleName == request.RoleName).ToList();

            if (findPermissionByName is null || allRoles is null)
                return new() { Message = "Your role or permission couldn't be found" };

            foreach (var role in allRoles)
            {
                await _permissionWriteRepository.AddAsync(new Permission
                {

                    Title = request.PermissionName,
                    RolePermissions = new List<RolePermissions>
                    {
                        new RolePermissions{
                            RoleId = role.Id,
                        }
                    }

                });
            }

            await _permissionWriteRepository.SaveAsync();
            return new() { Message = "Permission was created successfully" };
        }
    }
}