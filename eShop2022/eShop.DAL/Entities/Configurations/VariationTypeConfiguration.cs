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
    public class VariationTypeConfiguration : IEntityTypeConfiguration<VariationType>
    {
        public void Configure(EntityTypeBuilder<VariationType> builder)
        {
            // Table
            builder.ToTable("t_VariationType");

            // Columns
            builder.HasKey(x => x.Id);

            //Relationships

        }
    }
}
