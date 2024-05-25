
using Hanan_csharp_backend_teamwork.src.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;
namespace sda_onsite_2_csharp_backend_teamwork.src.Databases;

public class DatabaseContext : DbContext
{
    private IConfiguration _config;

    public DbSet<Category> Category { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Order> Order { get; set; }
    // public DbSet<Payment> Payments { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>();
        modelBuilder.HasPostgresEnum<Status>();
    }
}



