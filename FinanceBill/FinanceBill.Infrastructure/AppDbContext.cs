using FinanceBill.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceBill.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Bill> Bills { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}