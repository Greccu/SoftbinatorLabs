using Microsoft.EntityFrameworkCore.Migrations;

namespace DBCS.Migrations
{
    public partial class Facultate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultateId",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Facultati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultati", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_FacultateId",
                table: "Studenti",
                column: "FacultateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Facultati_FacultateId",
                table: "Studenti",
                column: "FacultateId",
                principalTable: "Facultati",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Facultati_FacultateId",
                table: "Studenti");

            migrationBuilder.DropTable(
                name: "Facultati");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_FacultateId",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "FacultateId",
                table: "Studenti");
        }
    }
}
