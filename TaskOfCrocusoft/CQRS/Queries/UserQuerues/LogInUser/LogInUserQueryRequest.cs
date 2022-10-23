using MediatR;

namespace TaskOfCrocusoft.CQRS.Queries.UserQuerues.LogInUser
{
    public class LogInUserQueryRequest : IRequest<LogInUserQueryResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
