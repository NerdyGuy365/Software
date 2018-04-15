using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    public class CatalogContext :DbContext
    {

        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatalogBrand>(ConfigurCatalogBrand);
            builder.Entity<CatalogType>(ConfigurCatalogType);
            builder.Entity<CatalogItem>(ConfigurCatalogItem);
        }

        private void ConfigurCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");

            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired(true);

            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(c => c.Price)
                .IsRequired(true);

            builder.Property(c => c.PictureURL)
                .IsRequired(false);

            builder.HasOne(c => c.CatalogBrand)
                .WithMany()
                .HasForeignKey(c => c.CatalogBrandId);

            builder.HasOne(c => c.CatalogType)
                .WithMany()
                .HasForeignKey(c => c.CatalogTypeId);
        }

        private void ConfigurCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");

            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("catalog_brand_hilo")
                .IsRequired(true);

            builder.Property(c => c.Brand)
                .IsRequired(true)
                .HasMaxLength(100);
        }

        private void ConfigurCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo")
                .IsRequired(true);

            builder.Property(c => c.Type)
                .IsRequired(true)
                .HasMaxLength(100);
        }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }

        public DbSet<CatalogItem> CatalogItems { get; set; }
    }
}
