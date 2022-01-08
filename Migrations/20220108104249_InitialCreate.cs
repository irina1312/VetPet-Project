using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_pacient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume_insotitor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume_doctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_programarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");
        }
    }
}
