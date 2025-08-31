using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Entities;

namespace WebApplication2.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}