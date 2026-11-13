
namespace HousingCRM.App.Models;

public class Request
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Новое";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? MaxMessageId { get; set; }

    public int ResidentId { get; set; }
    public Resident? Resident { get; set; }

    public int ManagementCompanyId { get; set; }
    public ManagementCompany? ManagementCompany { get; set; }

    public int? EmployeeId { get; set; }
    public Employee? AssignedEmployee { get; set; }
}
