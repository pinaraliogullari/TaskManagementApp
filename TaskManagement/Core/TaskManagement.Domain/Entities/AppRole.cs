namespace TaskManagement.Domain.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; } = null!;
        public List<AppUser>? Users { get; set; }
    }
}
