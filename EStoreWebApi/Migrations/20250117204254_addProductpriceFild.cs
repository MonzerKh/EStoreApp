using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addProductpriceFild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Products");
        }
    }
}
