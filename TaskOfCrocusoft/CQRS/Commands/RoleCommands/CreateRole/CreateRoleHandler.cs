using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IPermissionRepository;
using CrocusoftTask.Repositories.IRepository.IRoleRepository;
using MediatR;
using TaskOfCrocusoft.Entities;

namespace TaskOfCrocusoft.CQRS.Commands.RoleCommands.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IPermissionReadRepository _permissionReadRepository;
        private readonly IPermissionWriteRepository _permissionWriteRepository;

        public CreateRoleHandler(IRoleWriteRepository roleWriteRepository,
            IPermissionReadRepository permissionReadRepository,
            IPermissionWriteRepository permissionWriteRepository,
            IRoleReadRepository roleReadRepository)
        {
            _roleWriteRepository = roleWriteRepository;
            _permissionReadRepository = permissionReadRepository;
            _permissionWriteRepository = permissionWriteRepository;
            _roleReadRepository = roleReadRepository;
        }
        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {

            var currentRole = await _roleReadRepository.GetSingleAsync(r => r.RoleName == request.RoleName);

            if (currentRole is not null && request.RoleName == string.Empty)
                return new() { Message = "Something went wrong" };




            var newRole = new Role
            {
                RoleName = request.RoleName,
                UserRoles = new List<UserRoles> { 
                    new UserRoles{ 
                        UserId = request.UserId,
                        Role = new Role{
                            RoleName = request.RoleName
                        }
                    }
                },
                RolePermissions = new List<RolePermissions>()
            };
            foreach (var item in request.PermissionTypes)
            {
                newRole.RolePermissions.Add(new RolePermissions { 
                    Permission = new Permission {
                        Title = item
                    }
                });
            }


            //foreach (var p in request.PermissionTypes)
            //{
            //    var currentPermission = await _permissionReadRepository.GetSingleAsync(per => per.Title == p);
            //    if (currentPermission is null)
            //        continue;
            //    await _permissionWriteRepository.AddAsync(new Permission
            //    {
            //        Title = p,
            //        RolePermissions = new List<RolePermissions> {
            //            new RolePermissions
            //            {
            //                Role = newRole
            //            }
            //        }
            //    });
            //}


            await _roleWriteRepository.AddAsync(newRole);
            await _roleWriteRepository.SaveAsync();
            return new() { Message="All good your role added succesfully!"};
        }
    }
}