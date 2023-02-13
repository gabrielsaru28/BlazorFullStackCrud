using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorFullStackCrud.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 3,
                column: "AllergyName",
                value: "Alergie la praf");

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergyId", "AllergyName" },
                values: new object[,]
                {
                    { 4, "Alergie la lactoza" },
                    { 5, "Alergie la capsuni" }
                });

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "AllergyId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 6,
                column: "AllergyId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 7,
                column: "AllergyId",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 3,
                column: "AllergyName",
                value: "Alergie la capsuni");

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergyId", "AllergyName" },
                values: new object[,]
                {
                    { 1, "Alergie la praf" },
                    { 2, "Alergie la lactoza" }
                });

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "AllergyId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 6,
                column: "AllergyId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 7,
                column: "AllergyId",
                value: 3);
        }
    }
}
