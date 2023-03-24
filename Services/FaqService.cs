using Microsoft.EntityFrameworkCore;
using WebAPI.Db;
using WebAPI.Db.Entities;
using System;
using WebAPI.Requests;

namespace WebAPI.Services;

public interface IFaqService
{
    public Task<List<Faq>> GetList();
    public Task<Faq> GetById(string id);
    public Task<string?> Create(FaqRequest data);
    public Task<Tuple<bool,string, string>> Update(string id, FaqRequest collection);
    public Task<string?> Delete(string id);
}

public class FaqService : IFaqService
{
    private readonly ApplicationDbContext _db;

    public FaqService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Faq>> GetList()
    {
        var result = await _db.Faqs.OrderBy(x => x.CreatedAt).ToListAsync();

        return result;
    }

    public async Task<Faq> GetById(string id)
    {
        var result = await _db.Faqs.Where(x => x.Id == Guid.Parse(id)).FirstOrDefaultAsync();

        return result;
    }

    public async Task<string?> Create(FaqRequest data)
    {
        var faq = new Faq
        {
            Id = Guid.NewGuid(),
            Title = data.Title,
            Content = data.Content,
            Answer = data.Answer,
            CreatedBy = "Admin",
            CreatedAt = DateTime.Now
        };
        
        await _db.AddAsync(faq);

        try
        {
            await _db.SaveChangesAsync();
            
            return "Success";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<Tuple<bool,string, string>> Update(string id, FaqRequest data)
    {
        var message = "";

        var existData = await _db.Faqs.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));

        if (existData == null)
        {
            message = "Data FAQ dengan " + id + " tidak ditemukan";

            return Tuple.Create(false, message, "");
        }

        try
        {
            existData.Title = data.Title;
            existData.Content = data.Content;
            existData.Answer = data.Answer;
            existData.UpdatedBy = "Admin";
            existData.UpdatedAt = DateTime.Now;

            _db.Update(existData);

            await _db.SaveChangesAsync();

            return Tuple.Create(true, message, "");
        }
        catch (Exception e)
        {
            return Tuple.Create(false, e.Message, "");
        }
    }

    public async Task<string?> Delete(string id)
    {
        var message = "";

        var existData = await _db.Faqs.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

        if (existData == null)
        {
            message = "Data FAQ dengan " + id + " tidak ditemukan";

            return message;
        }

        try
        {
            _db.Remove(existData);

            await _db.SaveChangesAsync();

            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}