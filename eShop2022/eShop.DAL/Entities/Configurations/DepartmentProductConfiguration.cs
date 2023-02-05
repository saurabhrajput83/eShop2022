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
    public class DepartmentProductConfiguration : IEntityTypeConfiguration<DepartmentProduct>
    {
        public void Configure(EntityTypeBuilder<DepartmentProduct> builder)
        {
            // Table
            builder.ToTable("t_DepartmentProduct");

            // Columns
            builder.HasKey(x => x.Id);

            //Relationships
            builder
                .HasOne<Department>(dp => dp.Department)
                .WithMany(d => d.DepartmentProducts)
                .HasForeignKey(dp => dp.DepartmentId);
            builder
                .HasOne<Product>(dp => dp.Product)
                .WithMany(d => d.DepartmentProducts)
                .HasForeignKey(dp => dp.ProductId);

        }
    }
}
