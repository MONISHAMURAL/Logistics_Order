using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistic_Order.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment_Id",
                table: "TotalCosts");

            migrationBuilder.AddColumn<int>(
                name: "TotalCostsCost_Id",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TotalCostsCost_Id",
                table: "Payments",
                column: "TotalCostsCost_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TotalCosts_TotalCostsCost_Id",
                table: "Payments",
                column: "TotalCostsCost_Id",
                principalTable: "TotalCosts",
                principalColumn: "Cost_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_TotalCosts_TotalCostsCost_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TotalCostsCost_Id",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TotalCostsCost_Id",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "Payment_Id",
                table: "TotalCosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
