using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPet.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_medic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reviewmedic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramareID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Programare_ProgramareID",
                        column: x => x.ProgramareID,
                        principalTable: "Programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProgramareID",
                table: "Review",
                column: "ProgramareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
