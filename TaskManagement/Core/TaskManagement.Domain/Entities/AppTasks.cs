namespace TaskManagement.Domain.Entities
{
    public class AppTasks:BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool State { get; set; }
        public int AppUserId { get; set; }
        public int PriorityId { get; set; }
    }
}
