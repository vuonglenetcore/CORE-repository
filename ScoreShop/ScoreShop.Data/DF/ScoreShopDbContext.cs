using Microsoft.EntityFrameworkCore;
using ScoreShop.Data.Entyties;

namespace ScoreShop.Data.DF
{
    public class ScoreShopDbContext : DbContext
    {
        public ScoreShopDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
