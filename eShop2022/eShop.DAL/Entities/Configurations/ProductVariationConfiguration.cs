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
    public class ProductVariationConfiguration : IEntityTypeConfiguration<ProductVariation>
    {
        public void Configure(EntityTypeBuilder<ProductVariation> builder)
        {
            // Table
            builder.ToTable("t_ProductVariation");

            // Columns
            builder.HasKey(x => x.Id);
     
            //Relationships

        }
    }
}
