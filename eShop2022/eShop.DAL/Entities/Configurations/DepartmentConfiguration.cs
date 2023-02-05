﻿using eShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table
            builder.ToTable("t_Department");

            // Columns
            builder.HasKey(x => x.Id);

            // Relationships
            //builder.HasOne(x => x.Parent)
            //  .WithMany()
            //  .HasForeignKey(x => x.ParentId);
        }

    }
}
