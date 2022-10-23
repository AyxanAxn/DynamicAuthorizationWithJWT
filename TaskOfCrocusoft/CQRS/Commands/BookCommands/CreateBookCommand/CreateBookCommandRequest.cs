using MediatR;

namespace TaskOfCrocusoft.CQRS.Commands.BookCommands.CreateBookCommand
{
    public class CreateBookCommandRequest : IRequest<CreateBookCommandResponse>
    {
        public string Genre { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
    }
}
