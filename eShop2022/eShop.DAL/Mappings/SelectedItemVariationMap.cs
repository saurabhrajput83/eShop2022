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
    public class SelectedItemVariationMap : EntityTypeConfiguration<SelectedItemVariation>
    {
        public SelectedItemVariationMap()
        {
            // Table
            this.ToTable("t_SelectedItemVariation");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Modifier).HasColumnName("Modifier");
            this.Property(x => x.SelectedItemId).HasColumnName("SelectedItemId");
            this.Property(x => x.VariationId).HasColumnName("VariationId");

            //Relationships

        }
    }
}
