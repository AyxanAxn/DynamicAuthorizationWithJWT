using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IPermissionRepository;
using CrocusoftTask.Repositories.IRepository.IUserRepository;
using MediatR;
using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Services.HashPassword;

namespace TaskOfCrocusoft.CQRS.Commands.UserCommands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IPermissionWriteRepository _permissionWriteRepository;
        public CreateUserHandler(IUserWriteRepository userWriteRepository, IPermissionWriteRepository permissionWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
            _permissionWriteRepository = permissionWriteRepository;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            HashPassword hashPassword = new();
            ICollection<UserRoles> listUserRoles = new List<UserRoles>();

            var getTheHashedPasword = hashPassword.HashThePassword(request.Password);
            var data = await _userWriteRepository.AddAsync(new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = getTheHashedPasword,
                Username = request.Username,
                UserRoles = new List<UserRoles>() {
                    new UserRoles {
                            Role = new Role {
                                RoleName = "Client",
                                RolePermissions = new List<RolePermissions>{
                                        new RolePermissions { Permission = new Permission
                                        {
                                            Title="CanGet"
                                        }
                                    }
                                }
                            },
                    }
                },
            });

            if (!data)
                return new() { Message = "Something went wrong" };

            await _userWriteRepository.SaveAsync();

            return new() { Message = "Successluffy added!" };
        }
    }
}