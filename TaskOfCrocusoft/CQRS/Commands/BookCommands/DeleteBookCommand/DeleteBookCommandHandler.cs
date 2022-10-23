using MediatR;
using TaskOfCrocusoft.Repositories.IRepository.IBookRepository;

namespace TaskOfCrocusoft.CQRS.Commands.BookCommands.DeleteBookCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookReadRepository _bookReadRepository;
        public DeleteBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {



            var bookForDelete = await _bookReadRepository.GetByIdAsync(request.BookId);

            if (bookForDelete is null)
                return new() { Message = "Something went wrong" };

            await _bookWriteRepository.RemoveAsync((bookForDelete.Id).ToString());

            await _bookWriteRepository.SaveAsync();
            return new() { Message = "Book was successfully removed" };


        }
    }
}
