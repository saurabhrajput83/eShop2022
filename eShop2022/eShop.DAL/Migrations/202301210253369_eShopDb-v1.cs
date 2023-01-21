namespace eShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eShopDbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                        Description = c.String(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        ProductId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.DepartmentId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                        Description = c.String(),
                        ParentId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                        ModelNumber = c.String(),
                        Summary = c.String(),
                        Description = c.String(),
                        ListPrice = c.Double(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        InfoUrl = c.String(),
                        ImageUrl = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsTaxable = c.Boolean(nullable: false),
                        HasFreeShipping = c.Boolean(nullable: false),
                        Weight = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        Breadth = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        BrandId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        AlertQuantity = c.Int(nullable: false),
                        WarehouseId = c.Int(),
                        ProductId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        AltTag = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        ProductId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductVariations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceModifier = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsHidden = c.Boolean(nullable: false),
                        ProductId = c.Int(),
                        VariationId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Variations", t => t.VariationId)
                .Index(t => t.ProductId)
                .Index(t => t.VariationId);
            
            CreateTable(
                "dbo.Variations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                        VariationTypeId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VariationTypes", t => t.VariationTypeId)
                .Index(t => t.VariationTypeId);
            
            CreateTable(
                "dbo.VariationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsHidden = c.Boolean(nullable: false),
                        Headline = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        ContactId = c.Int(),
                        Rating = c.Int(nullable: false),
                        Comments = c.String(),
                        ProductId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SelectedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ShoppingCartId = c.Int(),
                        ProductId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId)
                .Index(t => t.ShoppingCartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SelectedItemVariations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modifier = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SelectedItemId = c.Int(),
                        VariationId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SelectedItems", t => t.SelectedItemId)
                .ForeignKey("dbo.Variations", t => t.VariationId)
                .Index(t => t.SelectedItemId)
                .Index(t => t.VariationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelectedItemVariations", "VariationId", "dbo.Variations");
            DropForeignKey("dbo.SelectedItemVariations", "SelectedItemId", "dbo.SelectedItems");
            DropForeignKey("dbo.SelectedItems", "ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.SelectedItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVariations", "VariationId", "dbo.Variations");
            DropForeignKey("dbo.Variations", "VariationTypeId", "dbo.VariationTypes");
            DropForeignKey("dbo.ProductVariations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Inventories", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DepartmentProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.DepartmentProducts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "ParentId", "dbo.Departments");
            DropIndex("dbo.SelectedItemVariations", new[] { "VariationId" });
            DropIndex("dbo.SelectedItemVariations", new[] { "SelectedItemId" });
            DropIndex("dbo.SelectedItems", new[] { "ProductId" });
            DropIndex("dbo.SelectedItems", new[] { "ShoppingCartId" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Variations", new[] { "VariationTypeId" });
            DropIndex("dbo.ProductVariations", new[] { "VariationId" });
            DropIndex("dbo.ProductVariations", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Inventories", new[] { "ProductId" });
            DropIndex("dbo.Inventories", new[] { "WarehouseId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Departments", new[] { "ParentId" });
            DropIndex("dbo.DepartmentProducts", new[] { "ProductId" });
            DropIndex("dbo.DepartmentProducts", new[] { "DepartmentId" });
            DropTable("dbo.SelectedItemVariations");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.SelectedItems");
            DropTable("dbo.Reviews");
            DropTable("dbo.VariationTypes");
            DropTable("dbo.Variations");
            DropTable("dbo.ProductVariations");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Inventories");
            DropTable("dbo.Products");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentProducts");
            DropTable("dbo.Brands");
        }
    }
}
