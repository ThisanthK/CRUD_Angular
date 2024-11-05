﻿using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Authentication> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
