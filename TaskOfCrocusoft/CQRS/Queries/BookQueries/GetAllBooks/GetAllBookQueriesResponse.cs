using TaskOfCrocusoft.Entities;

namespace TaskOfCrocusoft.CQRS.Queries.BookQueries.GetAllBooks
{
    public class GetAllBookQueriesResponse
    {
        public ICollection<Book> AllBooks { get; set; }
    }
}
