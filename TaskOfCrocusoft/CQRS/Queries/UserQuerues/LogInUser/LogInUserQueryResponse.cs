using CrocusoftTask.Entities;
using TaskOfCrocusoft.DTOs;

namespace TaskOfCrocusoft.CQRS.Queries.UserQuerues.LogInUser
{
    public class LogInUserQueryResponse
    {
        public Token Token { get; set; }

        public User CurrentUser { get; set; }
    }
}
