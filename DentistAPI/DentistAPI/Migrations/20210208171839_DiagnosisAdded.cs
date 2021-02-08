using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAPI.Migrations
{
    public partial class DiagnosisAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_ClassificationOfDisease_ClassificationOfDiseaseId",
                table: "Diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Encounter_EncounterId",
                table: "Diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosis_Tooth_ToothId",
                table: "Diagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Encounter_Patient_PatientId",
                table: "Encounter");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothRecord_Patient_PatientId",
                table: "ToothRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothRecord_Tooth_ToothId",
                table: "ToothRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecord_Diagnosis_DiagnosisId",
                table: "ToothSurfaceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecord_ToothRecord_ToothRecordId",
                table: "ToothSurfaceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothToothSurface_Tooth_ToothId",
                table: "ToothToothSurface");

            migrationBuilder.DropIndex(
                name: "IX_ToothSurfaceRecord_DiagnosisId",
                table: "ToothSurfaceRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToothRecord",
                table: "ToothRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tooth",
                table: "Tooth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosis",
                table: "Diagnosis");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "ToothSurfaceRecord");

            migrationBuilder.RenameTable(
                name: "ToothRecord",
                newName: "ToothRecords");

            migrationBuilder.RenameTable(
                name: "Tooth",
                newName: "Teeth");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "Diagnosis",
                newName: "Diagnoses");

            migrationBuilder.RenameIndex(
                name: "IX_ToothRecord_ToothId",
                table: "ToothRecords",
                newName: "IX_ToothRecords_ToothId");

            migrationBuilder.RenameIndex(
                name: "IX_ToothRecord_PatientId",
                table: "ToothRecords",
                newName: "IX_ToothRecords_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_ToothId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_ToothId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_EncounterId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_EncounterId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnosis_ClassificationOfDiseaseId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_ClassificationOfDiseaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToothRecords",
                table: "ToothRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teeth",
                table: "Teeth",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ToothSurfaceRecordDiagnoses",
                columns: table => new
                {
                    ToothSurfaceRecordId = table.Column<int>(type: "integer", nullable: false),
                    DiagnosisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothSurfaceRecordDiagnoses", x => new { x.DiagnosisId, x.ToothSurfaceRecordId });
                    table.ForeignKey(
                        name: "FK_ToothSurfaceRecordDiagnoses_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToothSurfaceRecordDiagnoses_ToothSurfaceRecord_ToothSurface~",
                        column: x => x.ToothSurfaceRecordId,
                        principalTable: "ToothSurfaceRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassificationOfDisease",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "K02", "Zubní kaz" });

            migrationBuilder.CreateIndex(
                name: "IX_ToothSurfaceRecordDiagnoses_ToothSurfaceRecordId",
                table: "ToothSurfaceRecordDiagnoses",
                column: "ToothSurfaceRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_ClassificationOfDisease_ClassificationOfDiseaseId",
                table: "Diagnoses",
                column: "ClassificationOfDiseaseId",
                principalTable: "ClassificationOfDisease",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Encounter_EncounterId",
                table: "Diagnoses",
                column: "EncounterId",
                principalTable: "Encounter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_ToothRecords_ToothId",
                table: "Diagnoses",
                column: "ToothId",
                principalTable: "ToothRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encounter_Patients_PatientId",
                table: "Encounter",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothRecords_Patients_PatientId",
                table: "ToothRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothRecords_Teeth_ToothId",
                table: "ToothRecords",
                column: "ToothId",
                principalTable: "Teeth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecord_ToothRecords_ToothRecordId",
                table: "ToothSurfaceRecord",
                column: "ToothRecordId",
                principalTable: "ToothRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothToothSurface_Teeth_ToothId",
                table: "ToothToothSurface",
                column: "ToothId",
                principalTable: "Teeth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_ClassificationOfDisease_ClassificationOfDiseaseId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Encounter_EncounterId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_ToothRecords_ToothId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Encounter_Patients_PatientId",
                table: "Encounter");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothRecords_Patients_PatientId",
                table: "ToothRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothRecords_Teeth_ToothId",
                table: "ToothRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecord_ToothRecords_ToothRecordId",
                table: "ToothSurfaceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothToothSurface_Teeth_ToothId",
                table: "ToothToothSurface");

            migrationBuilder.DropTable(
                name: "ToothSurfaceRecordDiagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToothRecords",
                table: "ToothRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teeth",
                table: "Teeth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnoses",
                table: "Diagnoses");

            migrationBuilder.DeleteData(
                table: "ClassificationOfDisease",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "ToothRecords",
                newName: "ToothRecord");

            migrationBuilder.RenameTable(
                name: "Teeth",
                newName: "Tooth");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "Diagnoses",
                newName: "Diagnosis");

            migrationBuilder.RenameIndex(
                name: "IX_ToothRecords_ToothId",
                table: "ToothRecord",
                newName: "IX_ToothRecord_ToothId");

            migrationBuilder.RenameIndex(
                name: "IX_ToothRecords_PatientId",
                table: "ToothRecord",
                newName: "IX_ToothRecord_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_ToothId",
                table: "Diagnosis",
                newName: "IX_Diagnosis_ToothId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_EncounterId",
                table: "Diagnosis",
                newName: "IX_Diagnosis_EncounterId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_ClassificationOfDiseaseId",
                table: "Diagnosis",
                newName: "IX_Diagnosis_ClassificationOfDiseaseId");

            migrationBuilder.AddColumn<int>(
                name: "DiagnosisId",
                table: "ToothSurfaceRecord",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToothRecord",
                table: "ToothRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tooth",
                table: "Tooth",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosis",
                table: "Diagnosis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ToothSurfaceRecord_DiagnosisId",
                table: "ToothSurfaceRecord",
                column: "DiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_ClassificationOfDisease_ClassificationOfDiseaseId",
                table: "Diagnosis",
                column: "ClassificationOfDiseaseId",
                principalTable: "ClassificationOfDisease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Encounter_EncounterId",
                table: "Diagnosis",
                column: "EncounterId",
                principalTable: "Encounter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosis_Tooth_ToothId",
                table: "Diagnosis",
                column: "ToothId",
                principalTable: "Tooth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encounter_Patient_PatientId",
                table: "Encounter",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothRecord_Patient_PatientId",
                table: "ToothRecord",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothRecord_Tooth_ToothId",
                table: "ToothRecord",
                column: "ToothId",
                principalTable: "Tooth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecord_Diagnosis_DiagnosisId",
                table: "ToothSurfaceRecord",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecord_ToothRecord_ToothRecordId",
                table: "ToothSurfaceRecord",
                column: "ToothRecordId",
                principalTable: "ToothRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothToothSurface_Tooth_ToothId",
                table: "ToothToothSurface",
                column: "ToothId",
                principalTable: "Tooth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
