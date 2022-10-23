using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IUserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskOfCrocusoft.Abstractions.Services;
using TaskOfCrocusoft.DTOs;
using P = TaskOfCrocusoft.Services.HashPassword;

namespace TaskOfCrocusoft.CQRS.Queries.UserQuerues.LogInUser
{
    public class LogInUserQueryHandler : IRequestHandler<LogInUserQueryRequest, LogInUserQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITokenHandler _tokenHandler;
        public LogInUserQueryHandler(IUserReadRepository userReadRepository, ITokenHandler tokenHandler)
        {
            _userReadRepository = userReadRepository;
            _tokenHandler = tokenHandler;
        }
        public async Task<LogInUserQueryResponse> Handle(LogInUserQueryRequest request, CancellationToken cancellationToken)
        {
            P.HashPassword hashPassword = new();
            var hashedPassword = hashPassword.HashThePassword(request.Password);

            var userFromReq = _userReadRepository.Table
                .Include(x => x.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .Where(u => u.Username == request.Username && u.Password == hashedPassword)
                .ToList().FirstOrDefault();
            if (userFromReq is null)
                return new();

            var userData = new User()
            {
                Username = userFromReq.Username,
                Email = userFromReq.Email,
                Surname = userFromReq.Surname,
                UserRoles = userFromReq.UserRoles,
                Name = userFromReq.Name
            };

            Token token = _tokenHandler.CreateAccessToken(500, userFromReq);
            return new() { Token = token, CurrentUser = userData };
        }
    }
}
