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
    public class SelectedItemVariationConfiguration : IEntityTypeConfiguration<SelectedItemVariation>
    {
        public void Configure(EntityTypeBuilder<SelectedItemVariation> builder)
        {
            // Table
            builder.ToTable("t_SelectedItemVariation");

            // Columns
            builder.HasKey(x => x.Id);
        
            //Relationships

        }
    }
}
