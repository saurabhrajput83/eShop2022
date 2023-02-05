using eShop.DAL.Entities;
using eShop.DAL.Entities.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Main
{
    public partial class eShopDbContext : DbContext
    {
        private readonly IConfigurationRoot Configuration;

        public eShopDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true);
            Configuration = builder.Build();
        }

        public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentProductConfiguration());
            //modelBuilder.ApplyConfiguration(new eShopUsersConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductVariationConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new SelectedItemConfiguration());
            modelBuilder.ApplyConfiguration(new SelectedItemVariationConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new VariationConfiguration());
            modelBuilder.ApplyConfiguration(new VariationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("eShopDatabase"));

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentProduct> DepartmentProducts { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductVariation> ProductVariations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SelectedItem> SelectedItems { get; set; }
        public virtual DbSet<SelectedItemVariation> SelectedItemVariations { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Variation> Variations { get; set; }
        public virtual DbSet<VariationType> VariationTypes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

    }
}
