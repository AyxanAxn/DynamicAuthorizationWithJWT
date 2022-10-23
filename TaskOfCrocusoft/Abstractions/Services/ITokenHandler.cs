using CrocusoftTask.Entities;
using TaskOfCrocusoft.DTOs;

namespace TaskOfCrocusoft.Abstractions.Services
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minute,User user);
    }
}
