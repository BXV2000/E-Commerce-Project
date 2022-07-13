using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    public partial class removecustomerratingconnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_CustomersId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CustomersId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomersId",
                table: "Ratings",
                column: "CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_CustomersId",
                table: "Ratings",
                column: "CustomersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
