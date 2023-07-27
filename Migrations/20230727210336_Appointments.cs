using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Appointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Patients_PatientId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Staff_StaffId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_PatientId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_StaffId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Treatments");

            migrationBuilder.AddColumn<long>(
                name: "AppointmentId",
                table: "Treatments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AppointmentStatus = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StaffId = table.Column<long>(type: "bigint", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AppointmentId",
                table: "Treatments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StaffId",
                table: "Appointments",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Appointments_AppointmentId",
                table: "Treatments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Appointments_AppointmentId",
                table: "Treatments");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_AppointmentId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Treatments");

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Treatments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StaffId",
                table: "Treatments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientId",
                table: "Treatments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_StaffId",
                table: "Treatments",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Patients_PatientId",
                table: "Treatments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Staff_StaffId",
                table: "Treatments",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }
    }
}
