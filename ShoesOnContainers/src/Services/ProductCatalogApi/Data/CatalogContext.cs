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
        }

        private void ConfigurCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            tbuilder.ToTable("Catalog");
        }

        private void ConfigurCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            throw new NotImplementedException();
        }
    }
}
