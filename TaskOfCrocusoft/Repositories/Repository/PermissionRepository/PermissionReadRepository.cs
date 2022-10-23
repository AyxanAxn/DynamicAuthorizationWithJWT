using CrocusoftTask.AppDBContext;
using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IPermissionRepository;

namespace CrocusoftTask.Repositories.Repository.PermissionRepository
{
    public class PermissionReadRepository : ReadRepository<Permission>, IPermissionReadRepository
    {
        public PermissionReadRepository(ApplicationDBContext context) : base(context)
        { }
    }
}
