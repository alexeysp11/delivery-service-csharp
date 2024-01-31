using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryService.Core.Migrations
{
    public partial class AddedProductCategoryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryType",
                table: "ProductCategories",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategoryType",
                table: "ProductCategories");
        }
    }
}
