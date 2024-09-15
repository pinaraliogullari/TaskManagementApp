namespace TaskManagement.Domain.Entities
{
    public class AppTask : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool State { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }
        public List<TaskReport>? TaskReports { get; set; }

    }
}
