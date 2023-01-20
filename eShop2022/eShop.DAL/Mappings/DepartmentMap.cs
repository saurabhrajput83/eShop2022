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
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public  DepartmentMap()
        {
            // Table
            this.ToTable("t_Department");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.IsHidden).HasColumnName("IsHidden");
            //this.Property(x => x.IsTopLevelParent).HasColumnName("IsTopLevelParent");
            this.Property(x => x.ParentId).HasColumnName("ParentId");

            // Relationships
            //this.HasOne(x => x.Parent)
            //  .WithMany()
            //  .HasForeignKey(x => x.ParentId);
        }

    }
}
