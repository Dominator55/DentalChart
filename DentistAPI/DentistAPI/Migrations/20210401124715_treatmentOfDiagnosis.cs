using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAPI.Migrations
{
    public partial class treatmentOfDiagnosis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "ProcedureRecords",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultTreatmentId",
                table: "ClassificationOfDiseases",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureRecords_ReasonId",
                table: "ProcedureRecords",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationOfDiseases_DefaultTreatmentId",
                table: "ClassificationOfDiseases",
                column: "DefaultTreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassificationOfDiseases_Procedures_DefaultTreatmentId",
                table: "ClassificationOfDiseases",
                column: "DefaultTreatmentId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureRecords_Diagnoses_ReasonId",
                table: "ProcedureRecords",
                column: "ReasonId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassificationOfDiseases_Procedures_DefaultTreatmentId",
                table: "ClassificationOfDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureRecords_Diagnoses_ReasonId",
                table: "ProcedureRecords");

            migrationBuilder.DropIndex(
                name: "IX_ProcedureRecords_ReasonId",
                table: "ProcedureRecords");

            migrationBuilder.DropIndex(
                name: "IX_ClassificationOfDiseases_DefaultTreatmentId",
                table: "ClassificationOfDiseases");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "ProcedureRecords");

            migrationBuilder.DropColumn(
                name: "DefaultTreatmentId",
                table: "ClassificationOfDiseases");
        }
    }
}
