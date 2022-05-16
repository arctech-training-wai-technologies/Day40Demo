using Day40Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Day40Demo.DataAccess;

public class HrDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=HrSample;Integrated Security=True");
    }

    // add-migration NewDb
    // remove-migration
    // update-database
}