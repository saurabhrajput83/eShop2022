﻿using eShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Mappings
{
    public class DepartmentProductMap : EntityTypeConfiguration<DepartmentProduct>
    {
        public DepartmentProductMap()
        {
            // Table
            this.ToTable("t_DepartmentProduct");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.DepartmentId).HasColumnName("DepartmentId");
            this.Property(x => x.ProductId).HasColumnName("ProductId");

            //Relationships

        }
    }
}
