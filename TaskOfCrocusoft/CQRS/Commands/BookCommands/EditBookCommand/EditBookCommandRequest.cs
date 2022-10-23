using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.BookCommands.EditBookCommand
{
    public class EditBookCommandRequest : IRequest<EditBookCommandResponse>
    {
        public Guid Id { get; set; }
        public string Genre { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
    }
}
