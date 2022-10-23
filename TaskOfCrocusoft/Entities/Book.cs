using TaskOfCrocusoft.Entities.Base;

namespace TaskOfCrocusoft.Entities
{
    public class Book : BaseComponent
    {
        public Guid Id { get; set; }
        public float Price { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
    }
}