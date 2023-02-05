using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class eShopDbv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Department_t_Department_ParentId",
                        column: x => x.ParentId,
                        principalTable: "t_Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_VariationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_VariationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    InfoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: false),
                    HasFreeShipping = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Breadth = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Product_t_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "t_Brand",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_Variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    VariationTypeId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Variation_t_VariationType_VariationTypeId",
                        column: x => x.VariationTypeId,
                        principalTable: "t_VariationType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_DepartmentProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_DepartmentProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_DepartmentProduct_t_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "t_Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_t_DepartmentProduct_t_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "t_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AlertQuantity = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Inventory_t_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "t_Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_t_Inventory_t_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "t_Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_ProductImage_t_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "t_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Review_t_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "t_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_SelectedItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_SelectedItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_SelectedItem_t_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "t_Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_t_SelectedItem_t_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "t_ShoppingCart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_ProductVariation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceModifier = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    VariationId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ProductVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_ProductVariation_t_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "t_Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_t_ProductVariation_t_Variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "t_Variation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "t_SelectedItemVariation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modifier = table.Column<double>(type: "float", nullable: false),
                    SelectedItemId = table.Column<int>(type: "int", nullable: true),
                    VariationId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_SelectedItemVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_SelectedItemVariation_t_SelectedItem_SelectedItemId",
                        column: x => x.SelectedItemId,
                        principalTable: "t_SelectedItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_t_SelectedItemVariation_t_Variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "t_Variation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Department_ParentId",
                table: "t_Department",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_DepartmentProduct_DepartmentId",
                table: "t_DepartmentProduct",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_DepartmentProduct_ProductId",
                table: "t_DepartmentProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Inventory_ProductId",
                table: "t_Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Inventory_WarehouseId",
                table: "t_Inventory",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Product_BrandId",
                table: "t_Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_t_ProductImage_ProductId",
                table: "t_ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_t_ProductVariation_ProductId",
                table: "t_ProductVariation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_t_ProductVariation_VariationId",
                table: "t_ProductVariation",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Review_ProductId",
                table: "t_Review",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_t_SelectedItem_ProductId",
                table: "t_SelectedItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_t_SelectedItem_ShoppingCartId",
                table: "t_SelectedItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_t_SelectedItemVariation_SelectedItemId",
                table: "t_SelectedItemVariation",
                column: "SelectedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_t_SelectedItemVariation_VariationId",
                table: "t_SelectedItemVariation",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Variation_VariationTypeId",
                table: "t_Variation",
                column: "VariationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_DepartmentProduct");

            migrationBuilder.DropTable(
                name: "t_Inventory");

            migrationBuilder.DropTable(
                name: "t_ProductImage");

            migrationBuilder.DropTable(
                name: "t_ProductVariation");

            migrationBuilder.DropTable(
                name: "t_Review");

            migrationBuilder.DropTable(
                name: "t_SelectedItemVariation");

            migrationBuilder.DropTable(
                name: "t_Department");

            migrationBuilder.DropTable(
                name: "t_Warehouse");

            migrationBuilder.DropTable(
                name: "t_SelectedItem");

            migrationBuilder.DropTable(
                name: "t_Variation");

            migrationBuilder.DropTable(
                name: "t_Product");

            migrationBuilder.DropTable(
                name: "t_ShoppingCart");

            migrationBuilder.DropTable(
                name: "t_VariationType");

            migrationBuilder.DropTable(
                name: "t_Brand");
        }
    }
}
