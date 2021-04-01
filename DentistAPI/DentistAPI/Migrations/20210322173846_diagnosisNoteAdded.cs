using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAPI.Migrations
{
    public partial class diagnosisNoteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Diagnoses",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Diagnoses");
        }
    }
}
