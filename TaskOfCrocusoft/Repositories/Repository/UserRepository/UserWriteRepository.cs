using CrocusoftTask.AppDBContext;
using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IUserRepository;

namespace CrocusoftTask.Repositories.Repository.UserRepository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ApplicationDBContext context) : base(context)
        { }
    }
}