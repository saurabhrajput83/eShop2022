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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {

        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            // Table
            builder.ToTable("t_Brand");

            // Columns
            builder.HasKey(x => x.Id);

            //Relationships

        }
    }
}
