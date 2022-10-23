using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.BookCommands.DeleteBookCommand
{
    public class DeleteBookCommandRequest : IRequest<DeleteBookCommandResponse>
    {
        public string BookId { get; set; }
    }
}
