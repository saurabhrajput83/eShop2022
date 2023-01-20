using eShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Mappings
{
    public class ProductImageMap : EntityTypeConfiguration<ProductImage>
    {
        public ProductImageMap()
        {
            // Table
            this.ToTable("t_ProductImage");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.AltTag).HasColumnName("AltTag");
            this.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
            this.Property(x => x.IsDefault).HasColumnName("IsDefault");
            this.Property(x => x.ProductId).HasColumnName("ProductId");

            //Relationships

        }
    }
}
