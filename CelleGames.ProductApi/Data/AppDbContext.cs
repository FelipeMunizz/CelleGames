using CelleGames.ProductApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CelleGames.ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base (options){}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }    
}
