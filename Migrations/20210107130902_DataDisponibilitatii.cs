using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Momeu_Olivia_Proiect.Migrations
{
    public partial class DataDisponibilitatii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                 name: "Pret",
                 table: "Produs",
                 type: "decimal(6, 2)",
                 nullable: false,
                 oldClrType: typeof(decimal),
                 oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDisponibilitatii",
                table: "Produs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDisponibilitatii",
                table: "Produs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Produs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");

        }
    }
}
