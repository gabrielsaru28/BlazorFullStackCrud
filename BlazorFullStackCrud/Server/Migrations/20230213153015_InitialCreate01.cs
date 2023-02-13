using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorFullStackCrud.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "HealthRecords",
                columns: new[] { "PatientId", "AllergiesAllergyId", "AllergyId", "MedicalHistory", "Medications", "PatientName" },
                values: new object[,]
                {
                    { 5, null, 1, "Healthy", "Pastile test", "Ion" },
                    { 6, null, 2, "Healthy", "Pastile lactoza", "John" },
                    { 7, null, 3, "Very Healthy", "Pastile1212 lactoza", "Mark" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "HealthRecords",
                columns: new[] { "PatientId", "AllergiesAllergyId", "AllergyId", "MedicalHistory", "Medications", "PatientName" },
                values: new object[,]
                {
                    { 1, null, 1, "Healthy", "Pastile test", "Ion" },
                    { 2, null, 2, "Healthy", "Pastile lactoza", "John" },
                    { 3, null, 3, "Very Healthy", "Pastile1212 lactoza", "Mark" }
                });
        }
    }
}
