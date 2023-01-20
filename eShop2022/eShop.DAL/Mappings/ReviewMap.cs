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
    public class ReviewMap : EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            // Table
            this.ToTable("t_Review");

            // Columns
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Comments).HasColumnName("Comments");
            this.Property(x => x.ContactId).HasColumnName("ContactId");
            this.Property(x => x.IsApproved).HasColumnName("IsApproved");
            this.Property(x => x.ProductId).HasColumnName("ProductId");
            this.Property(x => x.Rating).HasColumnName("Rating");
            this.Property(x => x.Headline).HasColumnName("Headline");

            //Relationships

        }
    }
}
