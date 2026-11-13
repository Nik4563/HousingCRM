
using HousingCRM.App.Data;
using HousingCRM.App.Models;
using Microsoft.EntityFrameworkCore;

namespace HousingCRM.App.Repositories;

public class RequestRepository
{
    private readonly AppDbContext _context;

    public RequestRepository(AppDbContext context)
    {
        _context = context;
    }

    // Получение всех обращений
    public async Task<List<Request>> GetAllAsync()
    {
        return await _context.Requests
            .AsNoTracking()
            .ToListAsync();
    }

    // Получение обращения по ID
    public async Task<Request?> GetByIdAsync(int id)
    {
        return await _context.Requests
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    // Создание нового обращения
    public async Task<Request> AddAsync(Request request)
    {
        ArgumentNullException.ThrowIfNull(request);

        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        return request;
    }

    // Обновление обращения
    public async Task<bool> UpdateAsync(
        int id,
        string title,
        string description,
        string status)
    {
        var request = await _context.Requests.FindAsync(id);

        if (request == null)
            return false;

        request.Title = title;
        request.Description = description;
        request.Status = status;

        await _context.SaveChangesAsync();

        return true;
    }

    // Удаление обращения
    public async Task<bool> DeleteAsync(int id)
    {
        var request = await _context.Requests.FindAsync(id);

        if (request == null)
            return false;

        _context.Requests.Remove(request);
        await _context.SaveChangesAsync();

        return true;
    }
}
