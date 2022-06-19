using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    public partial class updateratingrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRating");

            migrationBuilder.DropTable(
                name: "RatingVegetable");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerId",
                table: "Ratings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VegetableId",
                table: "Ratings",
                column: "VegetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Customers_CustomerId",
                table: "Ratings",
                column: "CustomerId",
                principalTable: "Customers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Customers_CustomerId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Vegetables_VegetableId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CustomerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_VegetableId",
                table: "Ratings");

            migrationBuilder.CreateTable(
                name: "CustomerRating",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    RatingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRating", x => new { x.CustomersId, x.RatingsId });
                    table.ForeignKey(
                        name: "FK_CustomerRating_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRating_Ratings_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingVegetable",
                columns: table => new
                {
                    RatingsId = table.Column<int>(type: "int", nullable: false),
                    VegetablesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingVegetable", x => new { x.RatingsId, x.VegetablesId });
                    table.ForeignKey(
                        name: "FK_RatingVegetable_Ratings_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatingVegetable_Vegetables_VegetablesId",
                        column: x => x.VegetablesId,
                        principalTable: "Vegetables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRating_RatingsId",
                table: "CustomerRating",
                column: "RatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingVegetable_VegetablesId",
                table: "RatingVegetable",
                column: "VegetablesId");
        }
    }
}
