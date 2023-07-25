using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class StaffEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Staff_Educations_EducationId",
            //     table: "Staff");

            // migrationBuilder.DropIndex(
            //     name: "IX_Staff_EducationId",
            //     table: "Staff");

            // migrationBuilder.DropColumn(
            //     name: "EducationId",
            //     table: "Staff");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Staff",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "StaffId",
                table: "Educations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_StaffId",
                table: "Educations",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Staff_StaffId",
                table: "Educations",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Staff_StaffId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_StaffId",
                table: "Educations");

            // migrationBuilder.DropColumn(
            //     name: "Education",
            //     table: "Staff");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Educations");

            migrationBuilder.AddColumn<long>(
                name: "EducationId",
                table: "Staff",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_EducationId",
                table: "Staff",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Educations_EducationId",
                table: "Staff",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
