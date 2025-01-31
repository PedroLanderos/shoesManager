using Microsoft.EntityFrameworkCore;
using ShoesManager.Models;

namespace ShoesManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {   }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
            .HasOne(a => a.Store)
            .WithMany(s => s.Articles)
            .HasForeignKey(a => a.StoreId);
        }

    }
}
