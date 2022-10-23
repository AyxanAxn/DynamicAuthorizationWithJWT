using CrocusoftTask.AppDBContext;
using CrocusoftTask.Repositories.Repository;
using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Repositories.IRepository.IBookRepository;

namespace TaskOfCrocusoft.Repositories.Repository.BookRepository
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        public BookReadRepository(ApplicationDBContext context) : base(context)
        { }
    }
}
