using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class povezanInvoicesaostatkom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Invoices",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StaffId",
                table: "Invoices",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StaffId",
                table: "Invoices",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Staff_StaffId",
                table: "Invoices",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Patients_PatientId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Staff_StaffId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StaffId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Invoices");
        }
    }
}
