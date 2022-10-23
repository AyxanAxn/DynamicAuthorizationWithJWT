using TaskOfCrocusoft.Entities.Base;

namespace TaskOfCrocusoft.Entities
{
    public class Book : BaseComponent
    {
        public int Genre { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
    }
}