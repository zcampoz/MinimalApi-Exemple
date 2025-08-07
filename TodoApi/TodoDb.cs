using Microsoft.EntityFrameworkCore;

namespace TodoApi;
public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) 
        : base(options) { }
    public DbSet<TodoItem> Todos { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);
        modelBuilder.Entity<TodoItem>().Property(t => t.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<TodoItem>().Property(t => t.IsComplete).IsRequired();
    }
}
