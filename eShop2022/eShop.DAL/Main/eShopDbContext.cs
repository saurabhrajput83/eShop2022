using eShop.DAL.Entities;
using eShop.DAL.Mappings;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Main
{
    public class eShopDbContext : DbContext
    {
        private readonly bool _useDbContextOptions = false;
        //        private readonly string _eShopDBConnectionString =
        //"Data Source=srajput-azure-sql-database-server.database.windows.net;Initial Catalog=srajput-azure-default-database;User Id=srajput; Password=password21$";
        private readonly string _eShopDBConnectionString =
"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=srajputMain;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public eShopDbContext() : base("eShopDb")
        {
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<eShopDbContext, EF6Console.Migrations.Configuration>());
        }

        public eShopDbContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<eShopDbContext, EF6Console.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add<Brand>(new BrandMap());
            //modelBuilder.Configurations.Add<Department>(new DepartmentMap());
            //modelBuilder.Configurations.Add<DepartmentProduct>(new DepartmentProductMap());
            ////modelBuilder.Configurations.Add<eShopUsers>(new eShopUsersMap());
            //modelBuilder.Configurations.Add<Inventory>(new InventoryMap());
            //modelBuilder.Configurations.Add<ProductImage>(new ProductImageMap());
            //modelBuilder.Configurations.Add<Product>(new ProductMap());
            //modelBuilder.Configurations.Add<ProductVariation>(new ProductVariationMap());
            //modelBuilder.Configurations.Add<Review>(new ReviewMap());
            //modelBuilder.Configurations.Add<SelectedItem>(new SelectedItemMap());
            //modelBuilder.Configurations.Add<SelectedItemVariation>(new SelectedItemVariationMap());
            //modelBuilder.Configurations.Add<ShoppingCart>(new ShoppingCartMap());
            //modelBuilder.Configurations.Add<Variation>(new VariationMap());
            //modelBuilder.Configurations.Add<VariationType>(new VariationTypeMap());
            //modelBuilder.Configurations.Add<Warehouse>(new WarehouseMap());

        }

        public DbSet<Brand> Brands { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<DepartmentProduct> DepartmentProducts { get; set; } = default!;
        //public DbSet<eShopUser> eShopUsers { get; set; } = default!;
        public DbSet<Inventory> Inventories { get; set; } = default!;
        public DbSet<ProductImage> ProductImages { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductVariation> ProductVariations { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<SelectedItem> SelectedItems { get; set; } = default!;
        public DbSet<SelectedItemVariation> SelectedItemVariations { get; set; } = default!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = default!;
        public DbSet<Variation> Variations { get; set; } = default!;
        public DbSet<VariationType> VariationTypes { get; set; } = default!;
        public DbSet<Warehouse> Warehouses { get; set; } = default!;

    }
}
