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
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Table
            builder.ToTable("t_ProductImage");

            // Columns
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.AltTag).HasColumnName("AltTag");
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
            builder.Property(x => x.IsDefault).HasColumnName("IsDefault");
            builder.Property(x => x.ProductId).HasColumnName("ProductId");

            //Relationships

        }
    }
}
