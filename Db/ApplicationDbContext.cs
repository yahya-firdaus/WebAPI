using Microsoft.EntityFrameworkCore;
using WebAPI.Db.Entities;
using WebAPI.Db.Seeders;

namespace WebAPI.Db;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Token>? Tokens { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Faq>? Faqs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Tokens)
            .WithOne(p => p.User);

        modelBuilder.Seed();
    }
}