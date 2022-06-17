using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    public partial class editrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Ratings_RatingId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Vegetables_VegetableId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_VegetableId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RatingId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VegetableId",
                table: "Ratings",
                column: "VegetableId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RatingId",
                table: "Customers",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Ratings_RatingId",
                table: "Customers",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Vegetables_VegetableId",
                table: "Ratings",
                column: "VegetableId",
                principalTable: "Vegetables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
