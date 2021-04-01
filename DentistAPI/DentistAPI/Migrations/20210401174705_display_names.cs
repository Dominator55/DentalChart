using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAPI.Migrations
{
    public partial class display_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Procedures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "ClassificationOfDiseases",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClassificationOfDiseases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayName",
                value: "Decay");

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Code", "DisplayName", "Name" },
                values: new object[] { 1, "00920", "White Filling", "Ošetření stálého zubu fotokompozitní výplní" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "ClassificationOfDiseases");
        }
    }
}
