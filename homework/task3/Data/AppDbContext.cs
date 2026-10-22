using Microsoft.EntityFrameworkCore;
using task3.Models;

namespace task3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("Users");
            e.HasKey(x => x.Id);
            e.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            e.HasIndex(x => x.UserName).IsUnique();
            e.Property(x => x.PasswordHash).IsRequired();
        });
    }
}
