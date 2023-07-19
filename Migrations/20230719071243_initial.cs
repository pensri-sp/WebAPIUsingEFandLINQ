using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSQLStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Catogories",
                schema: "dbo",
                columns: table => new
                {
                    CatagoryName = table.Column<string>(type: "varchar(64)", nullable: false),
                    CategoryStatus = table.Column<int>(type: "int", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catogories", x => x.CatagoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    ProductName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UnitStock = table.Column<int>(type: "int", nullable: false),
                    ProductPicture = table.Column<string>(type: "varchar(128)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Catogories_CatagoryId",
                        column: x => x.CatagoryId,
                        principalSchema: "dbo",
                        principalTable: "Catogories",
                        principalColumn: "CatagoryId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "ตารางเก็บข้อมูลสินค้า");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryId",
                schema: "dbo",
                table: "Products",
                column: "CatagoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Catogories",
                schema: "dbo");
        }
    }
}
