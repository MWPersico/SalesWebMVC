using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public DbSet<SalesWebMVC.Models.Department> Department { get; set; } = default!;
        public DbSet<SalesWebMVC.Models.Seller> Seller { get; set; } = default!;
        public DbSet<SalesWebMVC.Models.SalesRecord> SalesRecord { get; set; } = default!;

        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Sellers)
                .HasForeignKey(s => s.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<SalesRecord>()
                .HasOne(sr => sr.Seller)
                .WithMany(s => s.Sales)
                .HasForeignKey(sr => sr.SellerId)
                .IsRequired();
        }
    }
}
