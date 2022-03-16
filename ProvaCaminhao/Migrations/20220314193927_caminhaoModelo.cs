using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaCaminhao.Migrations
{
    public partial class caminhaoModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    modeloID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caminhao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_caminhao_modelo_modeloID",
                        column: x => x.modeloID,
                        principalTable: "modelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_caminhao_modeloID",
                table: "caminhao",
                column: "modeloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caminhao");

            migrationBuilder.DropTable(
                name: "modelo");
        }
    }
}
