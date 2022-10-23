using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.UserCommands.RemoveUser
{
    public class RemoveUserRequest:IRequest<RemoveUserResponse>
    {
        public Guid Id { get; set; }
    }
}
