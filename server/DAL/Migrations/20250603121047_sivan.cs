using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class sivan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRental");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Rentals");

            migrationBuilder.CreateTable(
                name: "PurchaseRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    Scores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRentals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRentals");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
