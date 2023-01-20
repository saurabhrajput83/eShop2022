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
    public class VariationTypeMap : EntityTypeConfiguration<VariationType>
    {
        public VariationTypeMap()
        {
            // Table
            this.ToTable("t_VariationType");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.Name).HasColumnName("Name");

            //Relationships

        }
    }
}
