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
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Table
            this.ToTable("t_Product");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.BrandId).HasColumnName("BrandId");
            this.Property(x => x.Breadth).HasColumnName("Breadth");
            this.Property(x => x.HasFreeShipping).HasColumnName("HasFreeShipping");
            this.Property(x => x.Height).HasColumnName("Height");
            this.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
            this.Property(x => x.IsActive).HasColumnName("IsActive");
            this.Property(x => x.IsFeatured).HasColumnName("IsFeatured");
            this.Property(x => x.IsHidden).HasColumnName("IsHidden");
            this.Property(x => x.IsTaxable).HasColumnName("IsTaxable");
            this.Property(x => x.Length).HasColumnName("Length");
            this.Property(x => x.ListPrice).HasColumnName("ListPrice");
            this.Property(x => x.ModelNumber).HasColumnName("ModelNumber");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.InfoUrl).HasColumnName("InfoUrl");
            this.Property(x => x.Summary).HasColumnName("Summary");
            this.Property(x => x.SellingPrice).HasColumnName("SellingPrice");
            this.Property(x => x.Weight).HasColumnName("Weight");

            // Relationships

        }
    }
}
