﻿namespace TaskManagement.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int AppRoleId { get; set; }
        public AppRole? Role { get; set; }
        public List<AppTask>? Tasks { get; set; }
        public List<Notification>? Notifications { get; set; }

    }
}
