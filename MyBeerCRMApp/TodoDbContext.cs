using Microsoft.EntityFrameworkCore;
using TodoManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoManager
{
    public class TodoDbContext : DbContext
    {
       public DbSet<TodoModel> todos { get; set; } = null!;

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
