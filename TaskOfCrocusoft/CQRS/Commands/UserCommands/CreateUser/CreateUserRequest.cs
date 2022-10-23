using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.UserCommands.CreateUser
{
    public class CreateUserRequest:IRequest<CreateUserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}