using CrocusoftTask.AppDBContext;
using CrocusoftTask.Repositories.Repository;
using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Repositories.IRepository.IBookRepository;

namespace TaskOfCrocusoft.Repositories.Repository.BookRepository
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        public BookWriteRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
