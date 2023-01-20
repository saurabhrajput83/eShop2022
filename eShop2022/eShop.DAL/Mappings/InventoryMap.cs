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
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            // Table
            this.ToTable("t_Inventory");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.AlertQuantity).HasColumnName("AlertQuantity");
            this.Property(x => x.ProductId).HasColumnName("ProductId");
            this.Property(x => x.Quantity).HasColumnName("Quantity");
            this.Property(x => x.WarehouseId).HasColumnName("WarehouseId");

            //Relationships

        }
    }
}
