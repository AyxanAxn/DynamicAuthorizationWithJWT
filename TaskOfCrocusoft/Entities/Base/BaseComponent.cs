namespace TaskOfCrocusoft.Entities.Base
{
    public class BaseComponent : IBase
    {
        public Guid Id { get; set; }
        public Guid CreaterId { get; set; }
        public Guid UpdaterId { get; set; }
        public Guid RemoverId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime RemoveDate { get; set; }
    }
}
