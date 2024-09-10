namespace TaskManagement.Domain.Entities
{
    public class Priority : BaseEntity
    {
        public string Definition { get; set; } = null!;
        public List<AppTask>? Tasks { get; set; }
    }
}
