using CommerceCommon.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // public DbSet<Product> Products { get; set; }
    
    public DbSet<Product> Products { get; set; }
}