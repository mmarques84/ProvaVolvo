using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaCaminhao.Migrations
{
    public partial class ANOMODELOFAB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_caminhao_modelo_modeloID",
                table: "caminhao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modelo",
                table: "modelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_caminhao",
                table: "caminhao");

            migrationBuilder.RenameTable(
                name: "modelo",
                newName: "Modelo");

            migrationBuilder.RenameTable(
                name: "caminhao",
                newName: "Caminhao");

            migrationBuilder.RenameIndex(
                name: "IX_caminhao_modeloID",
                table: "Caminhao",
                newName: "IX_Caminhao_modeloID");

            migrationBuilder.AddColumn<string>(
                name: "anoFabricao",
                table: "Modelo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "anoModelo",
                table: "Modelo",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelo",
                table: "Modelo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caminhao",
                table: "Caminhao",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Caminhao_Modelo_modeloID",
                table: "Caminhao",
                column: "modeloID",
                principalTable: "Modelo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caminhao_Modelo_modeloID",
                table: "Caminhao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelo",
                table: "Modelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caminhao",
                table: "Caminhao");

            migrationBuilder.DropColumn(
                name: "anoFabricao",
                table: "Modelo");

            migrationBuilder.DropColumn(
                name: "anoModelo",
                table: "Modelo");

            migrationBuilder.RenameTable(
                name: "Modelo",
                newName: "modelo");

            migrationBuilder.RenameTable(
                name: "Caminhao",
                newName: "caminhao");

            migrationBuilder.RenameIndex(
                name: "IX_Caminhao_modeloID",
                table: "caminhao",
                newName: "IX_caminhao_modeloID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modelo",
                table: "modelo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_caminhao",
                table: "caminhao",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_caminhao_modelo_modeloID",
                table: "caminhao",
                column: "modeloID",
                principalTable: "modelo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
