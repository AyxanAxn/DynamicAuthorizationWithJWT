using CrocusoftTask.Repositories.IRepository.IUserRepository;
using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.UserCommands.RemoveUser
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        public RemoveUserHandler(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            await _userWriteRepository.RemoveAsync((request.Id).ToString());

            return new();
        }
    }
}