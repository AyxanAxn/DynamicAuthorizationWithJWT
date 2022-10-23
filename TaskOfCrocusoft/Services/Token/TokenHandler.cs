using CrocusoftTask.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskOfCrocusoft.Abstractions.Services;
using T = TaskOfCrocusoft.DTOs;
using System.Linq;

namespace TaskOfCrocusoft.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public T.Token CreateAccessToken(int minute, User userClaim)
        {
            T.Token token = new();
            var claim = new List<Claim>() {
                new Claim(ClaimTypes.Name,(userClaim.Id).ToString()),
            };

            if (userClaim.UserRoles is not null)
            {
                List<string> allDatasAboutPermission = new();
                foreach (var user in userClaim.UserRoles)
                {
                    if (!allDatasAboutPermission.Contains(user.Role.RoleName))
                    {
                        allDatasAboutPermission.Add(user.Role.RoleName);
                        claim.Add(new Claim(ClaimTypes.Role, user.Role.RoleName));
                    }
                    foreach (var rolePermission in user.Role.RolePermissions)
                    {
                        if (!allDatasAboutPermission.Contains(rolePermission.Permission.Title))
                        {
                            allDatasAboutPermission.Add(rolePermission.Permission.Title);
                            claim.Add(new Claim(ClaimTypes.Role, rolePermission.Permission.Title));
                        }
                    }
                }
                allDatasAboutPermission.Clear();
            }
            
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                claims: claim.ToArray(),
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}