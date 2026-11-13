
namespace HousingCRM.App.Models;

public class ManagementCompany
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MaxBotId { get; set; } = string.Empty;

    public List<Resident> Residents { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();
    public List<Request> Requests { get; set; } = new();
}
