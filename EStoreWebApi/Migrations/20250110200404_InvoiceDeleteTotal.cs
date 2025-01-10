using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceDeleteTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceTotal",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
