using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAPI.Migrations
{
    public partial class CleanupInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecord_ToothRecords_ToothRecordId",
                table: "ToothSurfaceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecord_ToothSurfaces_ToothSurfaceId",
                table: "ToothSurfaceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecordDiagnoses_ToothSurfaceRecord_ToothSurface~",
                table: "ToothSurfaceRecordDiagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToothSurfaceRecord",
                table: "ToothSurfaceRecord");

            migrationBuilder.RenameTable(
                name: "ToothSurfaceRecord",
                newName: "ToothSurfaceRecords");

            migrationBuilder.RenameIndex(
                name: "IX_ToothSurfaceRecord_ToothSurfaceId",
                table: "ToothSurfaceRecords",
                newName: "IX_ToothSurfaceRecords_ToothSurfaceId");

            migrationBuilder.RenameIndex(
                name: "IX_ToothSurfaceRecord_ToothRecordId",
                table: "ToothSurfaceRecords",
                newName: "IX_ToothSurfaceRecords_ToothRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToothSurfaceRecords",
                table: "ToothSurfaceRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecordDiagnoses_ToothSurfaceRecords_ToothSurfac~",
                table: "ToothSurfaceRecordDiagnoses",
                column: "ToothSurfaceRecordId",
                principalTable: "ToothSurfaceRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecords_ToothRecords_ToothRecordId",
                table: "ToothSurfaceRecords",
                column: "ToothRecordId",
                principalTable: "ToothRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecords_ToothSurfaces_ToothSurfaceId",
                table: "ToothSurfaceRecords",
                column: "ToothSurfaceId",
                principalTable: "ToothSurfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecordDiagnoses_ToothSurfaceRecords_ToothSurfac~",
                table: "ToothSurfaceRecordDiagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecords_ToothRecords_ToothRecordId",
                table: "ToothSurfaceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ToothSurfaceRecords_ToothSurfaces_ToothSurfaceId",
                table: "ToothSurfaceRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToothSurfaceRecords",
                table: "ToothSurfaceRecords");

            migrationBuilder.RenameTable(
                name: "ToothSurfaceRecords",
                newName: "ToothSurfaceRecord");

            migrationBuilder.RenameIndex(
                name: "IX_ToothSurfaceRecords_ToothSurfaceId",
                table: "ToothSurfaceRecord",
                newName: "IX_ToothSurfaceRecord_ToothSurfaceId");

            migrationBuilder.RenameIndex(
                name: "IX_ToothSurfaceRecords_ToothRecordId",
                table: "ToothSurfaceRecord",
                newName: "IX_ToothSurfaceRecord_ToothRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToothSurfaceRecord",
                table: "ToothSurfaceRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecord_ToothRecords_ToothRecordId",
                table: "ToothSurfaceRecord",
                column: "ToothRecordId",
                principalTable: "ToothRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecord_ToothSurfaces_ToothSurfaceId",
                table: "ToothSurfaceRecord",
                column: "ToothSurfaceId",
                principalTable: "ToothSurfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToothSurfaceRecordDiagnoses_ToothSurfaceRecord_ToothSurface~",
                table: "ToothSurfaceRecordDiagnoses",
                column: "ToothSurfaceRecordId",
                principalTable: "ToothSurfaceRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
