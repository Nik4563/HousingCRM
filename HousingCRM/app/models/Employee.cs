
namespace HousingCRM.App.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public int ManagementCompanyId { get; set; }
    public ManagementCompany? ManagementCompany { get; set; }

    public List<Request> AssignedRequests { get; set; } = new();
}
