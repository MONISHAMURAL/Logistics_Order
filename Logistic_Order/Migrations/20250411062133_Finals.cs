using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistic_Order.Migrations
{
    /// <inheritdoc />
    public partial class Finals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingType_Id",
                table: "Shippings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingType_Id",
                table: "Shippings");
        }
    }
}
