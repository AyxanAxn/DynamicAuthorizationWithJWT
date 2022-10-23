using System.Linq.Expressions;
using TaskOfCrocusoft.Entities.Base;

namespace CrocusoftTask.Repositories.IRepository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseComponent
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}