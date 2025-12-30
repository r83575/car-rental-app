using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class e7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackagePurchase");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PackageId",
                table: "Purchases",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Packages_PackageId",
                table: "Purchases",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Packages_PackageId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PackageId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Purchases");

            migrationBuilder.CreateTable(
                name: "PackagePurchase",
                columns: table => new
                {
                    PackageListId = table.Column<int>(type: "int", nullable: false),
                    PurchaseListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePurchase", x => new { x.PackageListId, x.PurchaseListId });
                    table.ForeignKey(
                        name: "FK_PackagePurchase_Packages_PackageListId",
                        column: x => x.PackageListId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackagePurchase_Purchases_PurchaseListId",
                        column: x => x.PurchaseListId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackagePurchase_PurchaseListId",
                table: "PackagePurchase",
                column: "PurchaseListId");
        }
    }
}
