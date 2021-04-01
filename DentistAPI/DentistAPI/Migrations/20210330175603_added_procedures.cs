using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DentistAPI.Migrations
{
    public partial class added_procedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_ToothRecords_ToothId",
                table: "Diagnoses");

            migrationBuilder.RenameColumn(
                name: "ToothId",
                table: "Diagnoses",
                newName: "ToothRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_ToothId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_ToothRecordId");

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProcedureId = table.Column<int>(type: "integer", nullable: true),
                    EncounterId = table.Column<int>(type: "integer", nullable: true),
                    ToothRecordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureRecords_Encounter_EncounterId",
                        column: x => x.EncounterId,
                        principalTable: "Encounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureRecords_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProcedureRecords_ToothRecords_ToothRecordId",
                        column: x => x.ToothRecordId,
                        principalTable: "ToothRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureRecords_EncounterId",
                table: "ProcedureRecords",
                column: "EncounterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureRecords_ProcedureId",
                table: "ProcedureRecords",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureRecords_ToothRecordId",
                table: "ProcedureRecords",
                column: "ToothRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_ToothRecords_ToothRecordId",
                table: "Diagnoses",
                column: "ToothRecordId",
                principalTable: "ToothRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_ToothRecords_ToothRecordId",
                table: "Diagnoses");

            migrationBuilder.DropTable(
                name: "ProcedureRecords");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.RenameColumn(
                name: "ToothRecordId",
                table: "Diagnoses",
                newName: "ToothId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_ToothRecordId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_ToothId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_ToothRecords_ToothId",
                table: "Diagnoses",
                column: "ToothId",
                principalTable: "ToothRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
