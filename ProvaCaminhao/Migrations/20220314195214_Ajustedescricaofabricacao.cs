using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaCaminhao.Migrations
{
    public partial class Ajustedescricaofabricacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anoFabricao",
                table: "Modelo");

            migrationBuilder.AddColumn<string>(
                name: "anoFabricacao",
                table: "Modelo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anoFabricacao",
                table: "Modelo");

            migrationBuilder.AddColumn<string>(
                name: "anoFabricao",
                table: "Modelo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
