using TaskOfCrocusoft.Entities.Base;

namespace CrocusoftTask.Repositories.IRepository
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseComponent
    {
        bool Remove(T model);
        bool Update(T model);
        Task<int> SaveAsync();
        Task<bool> AddAsync(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        Task<bool> AddRangeAsync(List<T> datas);
    }
}
