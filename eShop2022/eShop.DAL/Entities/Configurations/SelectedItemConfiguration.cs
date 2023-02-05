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
    public class SelectedItemConfiguration : IEntityTypeConfiguration<SelectedItem>
    {
        public void Configure(EntityTypeBuilder<SelectedItem> builder)
        {
            // Table
            builder.ToTable("t_SelectedItem");

            // Columns
            builder.HasKey(x => x.Id);

            //Relationships
            builder
              .HasOne<Product>(si => si.Product)
              .WithMany(p => p.SelectedItems)
              .HasForeignKey(si => si.ProductId);
        }
    }
}
