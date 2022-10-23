using MediatR;
using TaskOfCrocusoft.Entities;
using TaskOfCrocusoft.Repositories.IRepository.IBookRepository;

namespace TaskOfCrocusoft.CQRS.Commands.BookCommands.EditBookCommand
{
    public class EditBookCommandHandler : IRequestHandler<EditBookCommandRequest, EditBookCommandResponse>
    {


        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookReadRepository _bookReadRepository;
        public EditBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<EditBookCommandResponse> Handle(EditBookCommandRequest request, CancellationToken cancellationToken)
        {
            var bookForEdit = await _bookReadRepository.GetByIdAsync((request.Id).ToString());
            if (bookForEdit is null)
                return new() { Message = "Something went wrong" };

            bookForEdit.PageCount = request.PageCount;
            bookForEdit.Author = request.Author;
            bookForEdit.Price = request.Price;
            bookForEdit.Genre = request.Genre;
            bookForEdit.Title = request.Title;
            _bookWriteRepository.Update(bookForEdit);
            
            await _bookWriteRepository.SaveAsync();
            return new() { Message = "Book was updated successfully" };
        }
    }
}
