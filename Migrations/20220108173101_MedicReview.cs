using Microsoft.EntityFrameworkCore.Migrations;

namespace VetPet.Migrations
{
    public partial class MedicReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Programare_ProgramareID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ProgramareID",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ProgramareID",
                table: "Review");

            migrationBuilder.CreateTable(
                name: "MedicReview",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramareID = table.Column<int>(type: "int", nullable: false),
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicReview", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicReview_Programare_ProgramareID",
                        column: x => x.ProgramareID,
                        principalTable: "Programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicReview_Review_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "Review",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicReview_ProgramareID",
                table: "MedicReview",
                column: "ProgramareID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicReview_ReviewID",
                table: "MedicReview",
                column: "ReviewID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicReview");

            migrationBuilder.AddColumn<int>(
                name: "ProgramareID",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProgramareID",
                table: "Review",
                column: "ProgramareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Programare_ProgramareID",
                table: "Review",
                column: "ProgramareID",
                principalTable: "Programare",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
