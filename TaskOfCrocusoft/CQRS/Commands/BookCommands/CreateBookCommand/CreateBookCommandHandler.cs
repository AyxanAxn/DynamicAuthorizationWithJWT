using MediatR;
using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Repositories.IRepository.IBookRepository;

namespace TaskOfCrocusoft.CQRS.Commands.BookCommands.CreateBookCommand
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {

        private readonly IBookWriteRepository _bookWriteRepository;
        public CreateBookCommandHandler(IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new() { Message = "Something went wrong" };
            var AddedBook = await _bookWriteRepository.AddAsync(new Book
            {

                Author = request.Author,
                Genre = request.Genre,
                Price = request.Price,
                Title = request.Title,
                PageCount = request.PageCount

            });



            await _bookWriteRepository.SaveAsync();
            return new() { Message = "Book was successfully added" };
        }
    }
}
