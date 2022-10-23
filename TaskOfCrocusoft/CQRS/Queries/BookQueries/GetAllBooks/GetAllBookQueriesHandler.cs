using MediatR;
using TaskOfCrocusoft.Repositories.IRepository.IBookRepository;

namespace TaskOfCrocusoft.CQRS.Queries.BookQueries.GetAllBooks
{
    public class GetAllBookQueriesHandler : IRequestHandler<GetAllBookQueriesRequest, GetAllBookQueriesResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;
        public GetAllBookQueriesHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

        public async Task<GetAllBookQueriesResponse> Handle(GetAllBookQueriesRequest request, CancellationToken cancellationToken)
        {
            return new()
            { AllBooks = _bookReadRepository.GetAll().ToList() };
        }
    }
}