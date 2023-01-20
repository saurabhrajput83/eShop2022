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
    public class VariationMap : EntityTypeConfiguration<Variation>
    {
        public VariationMap()
        {
            // Table
            this.ToTable("t_Variation");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.VariationTypeId).HasColumnName("VariationTypeId");
            
            //Relationships

        }
    }
}
