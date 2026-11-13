
namespace HousingCRM.App.Models;

public class Resident
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string MaxUserId { get; set; } = string.Empty;

    public int ManagementCompanyId { get; set; }
    public ManagementCompany? ManagementCompany { get; set; }

    public List<Request> Requests { get; set; } = new();
}
