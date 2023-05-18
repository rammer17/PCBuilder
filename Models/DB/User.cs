﻿namespace PCBuilder.Models.DB
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<PCBuild> Builds { get; set; }
    }
}
