using Microsoft.EntityFrameworkCore;
using WebAPI.Db.Entities;

namespace WebAPI.Db.Seeders;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = "admin@email.com",
            Address = "Bandung",
            IsVerified = true,
            PhoneNumber = "-",
            Name = "Administrator",
            Role = "Administrator",
            Password = BCrypt.Net.BCrypt.HashPassword("admin1234")
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = "user@email.com",
            Address = "Bandung",
            IsVerified = true,
            PhoneNumber = "085123486759",
            Name = "User",
            Role = "User",
            Password = BCrypt.Net.BCrypt.HashPassword("user1234")
        });
    }
}