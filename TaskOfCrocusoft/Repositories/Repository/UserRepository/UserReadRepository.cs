using CrocusoftTask.AppDBContext;
using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IUserRepository;

namespace CrocusoftTask.Repositories.Repository.UserRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ApplicationDBContext context) : base(context)
        { }
    }
}