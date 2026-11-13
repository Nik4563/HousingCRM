
using HousingCRM.App.Data;
using HousingCRM.App.Models;
using HousingCRM.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HousingCRM;

internal class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();

        // Применяем недостающие миграции к базе данных
        await context.Database.MigrateAsync();

        var repository = new RequestRepository(context);

        // 1. Создание управляющей компании
        var company = new ManagementCompany
        {
            Name = "УК Комфорт",
            MaxBotId = "bot_001"
        };

        context.ManagementCompanies.Add(company);
        await context.SaveChangesAsync();

        // 2. Создание жильца
        var resident = new Resident
        {
            FullName = "Иванов Иван Иванович",
            Address = "ул. Ленина, д. 10, кв. 5",
            MaxUserId = "user_001",
            ManagementCompanyId = company.Id
        };

        context.Residents.Add(resident);
        await context.SaveChangesAsync();

        // 3. CREATE — создание обращения
        var request = new Request
        {
            Title = "Протечка трубы",
            Description = "Протечка трубы в ванной комнате",
            Status = "Новое",
            ResidentId = resident.Id,
            ManagementCompanyId = company.Id
        };

        await repository.AddAsync(request);

        Console.WriteLine($"CREATE: Обращение #{request.Id} создано");

        // 4. READ — получение всех обращений
        var requests = await repository.GetAllAsync();

        Console.WriteLine("\nREAD: Список обращений");

        foreach (var item in requests)
        {
            Console.WriteLine(
                $"{item.Id} | {item.Title} | {item.Status}");
        }

        // 5. READ — поиск обращения по ID
        var found = await repository.GetByIdAsync(request.Id);

        Console.WriteLine(
            $"\nGET BY ID: {found?.Title}");

        // 6. UPDATE — изменение обращения
        bool updated = await repository.UpdateAsync(
            request.Id,
            "Протечка трубы",
            "Специалист направлен для устранения",
            "В работе"
        );

        var updatedRequest =
            await repository.GetByIdAsync(request.Id);

        Console.WriteLine(
            $"\nUPDATE: {updated}, статус: {updatedRequest?.Status}");

        // 7. DELETE — удаление обращения
        bool deleted =
            await repository.DeleteAsync(request.Id);

        Console.WriteLine($"\nDELETE: {deleted}");

        // 8. Проверка удаления
        var deletedRequest =
            await repository.GetByIdAsync(request.Id);

        Console.WriteLine(
            $"Проверка удаления: {(deletedRequest == null ? "Не найдено" : "Найдено")}");

        Console.WriteLine("\nТестирование завершено!");
    }
}
