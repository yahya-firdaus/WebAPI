using Microsoft.EntityFrameworkCore;
using WebAPI.Db;
using WebAPI.Db.Entities;
using System;
using WebAPI.Requests;

namespace WebAPI.Services;

public interface ILoginService
{
    public Task<User> Login(string email, string password);
}

public class LoginService : ILoginService
{
    private readonly ApplicationDbContext _db;

    public LoginService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User> Login(string email, string password)
    {
        var result = await _db.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

        if (!BCrypt.Net.BCrypt.Verify(password, result.Password)) return null;

        return result;
    }
}