﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DentistAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassificationOfDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationOfDisease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    healthInsuranceCompany = table.Column<int>(type: "integer", nullable: false),
                    PersonalAnamnesis = table.Column<string>(type: "text", nullable: true),
                    Allergies = table.Column<string>(type: "text", nullable: true),
                    PharmacologicalAnamnesis = table.Column<string>(type: "text", nullable: true),
                    Smoker = table.Column<bool>(type: "boolean", nullable: false),
                    SmokingDetail = table.Column<string>(type: "text", nullable: true),
                    Alcohol = table.Column<bool>(type: "boolean", nullable: false),
                    AlcoholDetail = table.Column<string>(type: "text", nullable: true),
                    Drugs = table.Column<bool>(type: "boolean", nullable: false),
                    DrugsDetail = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tooth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Localization = table.Column<string>(type: "text", nullable: true),
                    Deciduous = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tooth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToothSurfaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothSurfaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encounter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    ReportText = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encounter_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToothRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToothId = table.Column<int>(type: "integer", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToothRecord_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToothRecord_Tooth_ToothId",
                        column: x => x.ToothId,
                        principalTable: "Tooth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToothToothSurface",
                columns: table => new
                {
                    ToothId = table.Column<int>(type: "integer", nullable: false),
                    SurfaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothToothSurface", x => new { x.ToothId, x.SurfaceId });
                    table.ForeignKey(
                        name: "FK_ToothToothSurface_Tooth_ToothId",
                        column: x => x.ToothId,
                        principalTable: "Tooth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToothToothSurface_ToothSurfaces_SurfaceId",
                        column: x => x.SurfaceId,
                        principalTable: "ToothSurfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationOfDiseaseId = table.Column<int>(type: "integer", nullable: true),
                    EncounterId = table.Column<int>(type: "integer", nullable: true),
                    ToothId = table.Column<int>(type: "integer", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_ClassificationOfDisease_ClassificationOfDiseaseId",
                        column: x => x.ClassificationOfDiseaseId,
                        principalTable: "ClassificationOfDisease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Encounter_EncounterId",
                        column: x => x.EncounterId,
                        principalTable: "Encounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Tooth_ToothId",
                        column: x => x.ToothId,
                        principalTable: "Tooth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToothSurfaceRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToothRecordId = table.Column<int>(type: "integer", nullable: true),
                    ToothSurfaceId = table.Column<int>(type: "integer", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    DiagnosisId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothSurfaceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToothSurfaceRecord_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToothSurfaceRecord_ToothRecord_ToothRecordId",
                        column: x => x.ToothRecordId,
                        principalTable: "ToothRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToothSurfaceRecord_ToothSurfaces_ToothSurfaceId",
                        column: x => x.ToothSurfaceId,
                        principalTable: "ToothSurfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "Age", "Alcohol", "AlcoholDetail", "Allergies", "Drugs", "DrugsDetail", "Email", "Name", "NationalId", "PersonalAnamnesis", "PharmacologicalAnamnesis", "Phone", "Smoker", "SmokingDetail", "healthInsuranceCompany" },
                values: new object[] { 1, "Jabloňová 16 Brno 62100", 28, false, null, null, false, false, "jana.novakova@gmail.com", "Jana Nováková", "935617/4905", null, null, "655 475 877", false, null, 0 });

            migrationBuilder.InsertData(
                table: "Tooth",
                columns: new[] { "Id", "Deciduous", "Localization" },
                values: new object[,]
                {
                    { 32, false, "48" },
                    { 31, false, "47" },
                    { 30, false, "46" },
                    { 29, false, "45" },
                    { 28, false, "44" },
                    { 27, false, "43" },
                    { 26, false, "42" },
                    { 25, false, "41" },
                    { 24, false, "38" },
                    { 23, false, "37" },
                    { 22, false, "36" },
                    { 21, false, "35" },
                    { 19, false, "33" },
                    { 18, false, "32" },
                    { 17, false, "31" },
                    { 20, false, "34" },
                    { 15, false, "27" },
                    { 1, false, "11" },
                    { 2, false, "12" },
                    { 3, false, "13" },
                    { 4, false, "14" },
                    { 16, false, "28" },
                    { 6, false, "16" },
                    { 7, false, "17" },
                    { 5, false, "15" },
                    { 9, false, "21" },
                    { 10, false, "22" },
                    { 11, false, "23" },
                    { 12, false, "24" },
                    { 13, false, "25" },
                    { 14, false, "26" },
                    { 8, false, "18" }
                });

            migrationBuilder.InsertData(
                table: "ToothSurfaces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Labiální plocha" },
                    { 1, "Palatinální plocha" },
                    { 2, "Bukální plocha" },
                    { 3, "Distální plocha" },
                    { 4, "Meziální plocha" },
                    { 5, "Okluzní plocha" },
                    { 6, "Linguální plocua" },
                    { 8, "Incizální hrana" }
                });

            migrationBuilder.InsertData(
                table: "ToothToothSurface",
                columns: new[] { "SurfaceId", "ToothId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 5, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 5, 5 },
                    { 5, 16 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 28 },
                    { 5, 29 },
                    { 5, 30 },
                    { 5, 20 },
                    { 5, 31 },
                    { 5, 4 },
                    { 4, 31 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 4, 21 },
                    { 4, 32 },
                    { 4, 22 },
                    { 4, 24 },
                    { 4, 25 },
                    { 4, 26 },
                    { 4, 27 },
                    { 4, 28 },
                    { 4, 29 },
                    { 4, 30 },
                    { 4, 23 },
                    { 4, 14 },
                    { 5, 32 },
                    { 6, 18 },
                    { 7, 17 },
                    { 7, 18 },
                    { 7, 19 },
                    { 7, 25 },
                    { 7, 26 },
                    { 7, 27 },
                    { 8, 1 },
                    { 7, 11 },
                    { 8, 2 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 8, 17 },
                    { 8, 18 },
                    { 8, 19 },
                    { 8, 25 },
                    { 8, 3 },
                    { 6, 17 },
                    { 7, 10 },
                    { 7, 3 },
                    { 6, 19 },
                    { 6, 20 },
                    { 6, 21 },
                    { 6, 22 },
                    { 6, 23 },
                    { 6, 24 },
                    { 6, 25 },
                    { 7, 9 },
                    { 6, 26 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 6, 31 },
                    { 6, 32 },
                    { 7, 1 },
                    { 7, 2 },
                    { 6, 27 },
                    { 4, 13 },
                    { 4, 12 },
                    { 4, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 8 },
                    { 2, 22 },
                    { 2, 24 },
                    { 2, 28 },
                    { 2, 29 },
                    { 2, 30 },
                    { 2, 31 },
                    { 2, 32 },
                    { 3, 1 },
                    { 2, 23 },
                    { 3, 2 },
                    { 2, 7 },
                    { 2, 5 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 2, 6 },
                    { 1, 9 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 2, 4 },
                    { 1, 10 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 27 },
                    { 3, 28 },
                    { 3, 29 },
                    { 3, 30 },
                    { 3, 31 },
                    { 3, 32 },
                    { 4, 1 },
                    { 3, 26 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 3 },
                    { 3, 25 },
                    { 3, 24 },
                    { 3, 23 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 17 },
                    { 3, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 3, 21 },
                    { 3, 22 },
                    { 8, 26 },
                    { 8, 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_ClassificationOfDiseaseId",
                table: "Diagnosis",
                column: "ClassificationOfDiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_EncounterId",
                table: "Diagnosis",
                column: "EncounterId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_ToothId",
                table: "Diagnosis",
                column: "ToothId");

            migrationBuilder.CreateIndex(
                name: "IX_Encounter_PatientId",
                table: "Encounter",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ToothRecord_PatientId",
                table: "ToothRecord",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ToothRecord_ToothId",
                table: "ToothRecord",
                column: "ToothId");

            migrationBuilder.CreateIndex(
                name: "IX_ToothSurfaceRecord_DiagnosisId",
                table: "ToothSurfaceRecord",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_ToothSurfaceRecord_ToothRecordId",
                table: "ToothSurfaceRecord",
                column: "ToothRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ToothSurfaceRecord_ToothSurfaceId",
                table: "ToothSurfaceRecord",
                column: "ToothSurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ToothToothSurface_SurfaceId",
                table: "ToothToothSurface",
                column: "SurfaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToothSurfaceRecord");

            migrationBuilder.DropTable(
                name: "ToothToothSurface");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "ToothRecord");

            migrationBuilder.DropTable(
                name: "ToothSurfaces");

            migrationBuilder.DropTable(
                name: "ClassificationOfDisease");

            migrationBuilder.DropTable(
                name: "Encounter");

            migrationBuilder.DropTable(
                name: "Tooth");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
