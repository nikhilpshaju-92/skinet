using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Data.Migrations
{
    public partial class tablecorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductBrand_ProductBrnadId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductBrnadId",
                table: "Product",
                newName: "ProductBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductBrnadId",
                table: "Product",
                newName: "IX_Product_ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductBrand_ProductBrandId",
                table: "Product",
                column: "ProductBrandId",
                principalTable: "ProductBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductBrand_ProductBrandId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductBrandId",
                table: "Product",
                newName: "ProductBrnadId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductBrandId",
                table: "Product",
                newName: "IX_Product_ProductBrnadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductBrand_ProductBrnadId",
                table: "Product",
                column: "ProductBrnadId",
                principalTable: "ProductBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
