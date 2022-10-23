using CrocusoftTask.AppDBContext;
using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IRoleRepository;

namespace CrocusoftTask.Repositories.Repository.RoleRepository
{
    public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
