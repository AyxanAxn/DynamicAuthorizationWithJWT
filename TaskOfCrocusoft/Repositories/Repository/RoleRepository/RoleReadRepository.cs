using CrocusoftTask.AppDBContext;
using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IRoleRepository;

namespace CrocusoftTask.Repositories.Repository.RoleRepository
{
    public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
    {
        public RoleReadRepository(ApplicationDBContext context) : base(context)
        { }
    }
}