using Microsoft.EntityFrameworkCore;
using RedbullService.Models;
using RedBullService.Models;
using System.Security.Cryptography.X509Certificates;

namespace RedbullService.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Atleths> Atleths { get; set; }
        public DbSet<Basket> Basket { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Products ve Categories arasındaki ilişki
            modelBuilder.Entity<Categories>()
                .HasKey(c => new { c.urunId, c.kategoriId });

            modelBuilder.Entity<Categories>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(c => c.urunId);

            // Basket ve Products arasındaki ilişki
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Baskets)
                .HasForeignKey(b => b.urunId);

            // Basket ve User arasındaki ilişki
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.User)
                .WithMany(u => u.baskets)
                .HasForeignKey(b => b.kullaniciId);
        }
    }
}
    


    
