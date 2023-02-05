using eShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table
            builder.ToTable("t_Product");

            // Columns
            builder.HasKey(x => x.Id);

            // Relationships
            builder
               .HasOne<Brand>(p => p.Brand)
               .WithMany(b => b.Products)
               .HasForeignKey(p => p.BrandId);
        }
    }
}
