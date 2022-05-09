using Microsoft.EntityFrameworkCore.Migrations;

namespace app_calculadora.Migrations
{
    public partial class V02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setados",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    SomaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setados_Somas_SomaId",
                        column: x => x.SomaId,
                        principalTable: "Somas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setados_SomaId",
                table: "Setados",
                column: "SomaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setados");
        }
    }
}
