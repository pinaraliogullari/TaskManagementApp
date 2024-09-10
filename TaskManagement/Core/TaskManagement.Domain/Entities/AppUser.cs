﻿namespace TaskManagement.Domain.Entities
{
    public class AppUser:BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int AppRoleId { get; set; }
    }
}
