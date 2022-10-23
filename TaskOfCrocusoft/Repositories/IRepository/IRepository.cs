using Microsoft.EntityFrameworkCore;
using TaskOfCrocusoft.Entities.Base;

namespace CrocusoftTask.Repositories.IRepository
{
    public interface IRepository<T> where T : BaseComponent
    {
        DbSet<T> Table { get; }
    }
}
