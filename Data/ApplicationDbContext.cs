using Aphrodite.Models;
using Microsoft.EntityFrameworkCore;


namespace Aphrodite.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<ItemsModel> StoreItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    {
        
    }
    
    public DbSet<ItemsModel> Items { get; set; }
}