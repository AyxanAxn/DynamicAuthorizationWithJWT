using CrocusoftTask.AppDBContext;
using CrocusoftTask.Entities;
using CrocusoftTask.Repositories.IRepository.IPermissionRepository;

namespace CrocusoftTask.Repositories.Repository.PermissionRepository
{
    public class PermissionWriteRepository : WriteRepository<Permission>, IPermissionWriteRepository
    {
        public PermissionWriteRepository(ApplicationDBContext context) : base(context)
        { }
    }
}
