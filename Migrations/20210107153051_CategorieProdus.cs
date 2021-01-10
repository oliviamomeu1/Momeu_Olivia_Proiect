using Microsoft.EntityFrameworkCore.Migrations;

namespace Momeu_Olivia_Proiect.Migrations
{
    public partial class CategorieProdus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FurnizorID",
                table: "Produs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Furnizor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeFurnizor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnizor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieProdus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProdus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieProdus_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieProdus_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_FurnizorID",
                table: "Produs",
                column: "FurnizorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProdus_ProdusID",
                table: "CategorieProdus",
                column: "ProdusID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProdus_CategorieID",
                table: "CategorieProdus",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Furnizor_FurnizorID",
                table: "Produs",
                column: "FurnizorID",
                principalTable: "Furnizor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Furnizor_FurnizorID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "CategorieProdus");

            migrationBuilder.DropTable(
                name: "Furnizor");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Produs_FurnizorID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "FurnizorID",
                table: "Produs");
        }
    }
}
