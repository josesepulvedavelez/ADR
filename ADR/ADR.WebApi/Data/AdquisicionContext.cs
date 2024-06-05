using ADR.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ADR.WebApi.Data
{
    public class AdquisicionContext : DbContext
    {
        public AdquisicionContext(DbContextOptions<AdquisicionContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdquisicionModel>(entity =>
            {
                entity.HasKey(e => e.AdquisicionId);

                entity.Property(e => e.Presupuesto)
                    .HasComputedColumnSql("[ValorUnitario] * [Cantidad]")
                    .ValueGeneratedOnAddOrUpdate();
            });
        }

        public DbSet<AdquisicionModel> Adquisicion { get; set; }
    }
}
