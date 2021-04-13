using Microsoft.EntityFrameworkCore.Migrations;

namespace DBCS.Migrations
{
    public partial class Curs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursuri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursuri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCurs_Cursuri_CursId",
                        column: x => x.CursId,
                        principalTable: "Cursuri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCurs_Studenti_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCurs_CursId",
                table: "StudentCurs",
                column: "CursId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCurs_StudentId",
                table: "StudentCurs",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCurs");

            migrationBuilder.DropTable(
                name: "Cursuri");
        }
    }
}
