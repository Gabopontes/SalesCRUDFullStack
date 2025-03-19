using Microsoft.EntityFrameworkCore;
using SalesCRUD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCRUD.Infrastructure.Context
{
    public class DeveloperStoreContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        public DeveloperStoreContext(DbContextOptions<DeveloperStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey("SaleId");
        }
    }
}
