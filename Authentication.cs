﻿namespace testAPI.Models
{
    public class Authentication
    {
        public int Id { get; set; }
        public required string Fullname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        
    }
}
