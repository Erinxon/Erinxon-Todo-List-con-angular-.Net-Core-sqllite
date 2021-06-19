using Microsoft.EntityFrameworkCore;

namespace TodoListApi.Models
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
            
        }
        
        public DbSet<Task> Tasks { get; set; }
    }
}