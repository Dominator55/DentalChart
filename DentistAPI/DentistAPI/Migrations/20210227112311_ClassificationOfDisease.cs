using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAPI.Migrations
{
    public partial class ClassificationOfDisease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_ClassificationOfDisease_ClassificationOfDiseaseId",
                table: "Diagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassificationOfDisease",
                table: "ClassificationOfDisease");

            migrationBuilder.RenameTable(
                name: "ClassificationOfDisease",
                newName: "ClassificationOfDiseases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassificationOfDiseases",
                table: "ClassificationOfDiseases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_ClassificationOfDiseases_ClassificationOfDiseaseId",
                table: "Diagnoses",
                column: "ClassificationOfDiseaseId",
                principalTable: "ClassificationOfDiseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_ClassificationOfDiseases_ClassificationOfDiseaseId",
                table: "Diagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassificationOfDiseases",
                table: "ClassificationOfDiseases");

            migrationBuilder.RenameTable(
                name: "ClassificationOfDiseases",
                newName: "ClassificationOfDisease");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassificationOfDisease",
                table: "ClassificationOfDisease",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_ClassificationOfDisease_ClassificationOfDiseaseId",
                table: "Diagnoses",
                column: "ClassificationOfDiseaseId",
                principalTable: "ClassificationOfDisease",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
