
using HousingCRM.App.Models;
using Microsoft.EntityFrameworkCore;

namespace HousingCRM.App.Data;

public class AppDbContext : DbContext
{
    public DbSet<ManagementCompany> ManagementCompanies { get; set; }
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Request> Requests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=housingcrm.db");
        }
    }
}
