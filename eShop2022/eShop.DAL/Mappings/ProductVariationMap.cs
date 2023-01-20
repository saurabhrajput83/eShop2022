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
    public class ProductVariationMap : EntityTypeConfiguration<ProductVariation>
    {
        public ProductVariationMap()
        {
            // Table
            this.ToTable("t_ProductVariation");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.IsHidden).HasColumnName("IsHidden");
            this.Property(x => x.PriceModifier).HasColumnName("PriceModifier");
            this.Property(x => x.ProductId).HasColumnName("ProductId");
            this.Property(x => x.Quantity).HasColumnName("Quantity");
            this.Property(x => x.VariationId).HasColumnName("VariationId");

            //Relationships

        }
    }
}
