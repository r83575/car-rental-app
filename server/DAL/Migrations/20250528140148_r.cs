using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Purchases_PurchaseId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_PurchaseId",
                table: "Rentals");

            migrationBuilder.CreateTable(
                name: "PurchaseRental",
                columns: table => new
                {
                    PurchasesId = table.Column<int>(type: "int", nullable: false),
                    RentalsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRental", x => new { x.PurchasesId, x.RentalsId });
                    table.ForeignKey(
                        name: "FK_PurchaseRental_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRental_Rentals_RentalsId",
                        column: x => x.RentalsId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRental_RentalsId",
                table: "PurchaseRental",
                column: "RentalsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRental");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PurchaseId",
                table: "Rentals",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Purchases_PurchaseId",
                table: "Rentals",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
