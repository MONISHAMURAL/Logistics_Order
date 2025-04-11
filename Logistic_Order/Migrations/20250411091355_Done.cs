using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Logistic_Order.Migrations
{
    /// <inheritdoc />
    public partial class Done : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_TotalCosts_TotalCostsCost_Id",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalCosts_Payments_Cost_Id",
                table: "TotalCosts");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TotalCostsCost_Id",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TotalCostsCost_Id",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "Cost_Id",
                table: "TotalCosts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Cost_Id",
                table: "Payments",
                column: "Cost_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TotalCosts_Cost_Id",
                table: "Payments",
                column: "Cost_Id",
                principalTable: "TotalCosts",
                principalColumn: "Cost_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_TotalCosts_Cost_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Cost_Id",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "Cost_Id",
                table: "TotalCosts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TotalCosts_Payments_Cost_Id",
                table: "TotalCosts",
                column: "Cost_Id",
                principalTable: "Payments",
                principalColumn: "Payment_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
