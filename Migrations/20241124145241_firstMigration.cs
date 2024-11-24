using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wholesale_LINQ.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC27E3A18157", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manufact__3214EC27AF8431BB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Features = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StorageConditions = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Packing = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__3214EC275F07FFEE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Storages__3214EC273BA649A5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Features = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supplier__3214EC2786BBDC64", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__3214EC2785A1DD46", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_ProductsTypes",
                        column: x => x.TypeID,
                        principalTable: "ProductsTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StorageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC2778A79821", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Storages",
                        column: x => x.StorageID,
                        principalTable: "Storages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReceiptDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SendingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Receipts__3214EC27BE159E60", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receips_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Receipts_Products",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Receipts_Suppliers",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SendingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShippingMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Releases__3214EC27DB0685DA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Releases_Customers",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Releases_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Releases_Products",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StorageID",
                table: "Employees",
                column: "StorageID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerID",
                table: "Products",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeID",
                table: "Products",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_EmployeeID",
                table: "Receipts",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ProductID",
                table: "Receipts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_SupplierID",
                table: "Receipts",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_CustomerID",
                table: "Releases",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EmployeeID",
                table: "Releases",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ProductID",
                table: "Releases",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "ProductsTypes");
        }
    }
}
