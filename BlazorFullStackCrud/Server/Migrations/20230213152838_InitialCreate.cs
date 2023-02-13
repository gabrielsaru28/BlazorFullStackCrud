using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergyId", "AllergyName" },
                values: new object[] { 3, "Alergie la capsuni" });

            migrationBuilder.InsertData(
                table: "HealthRecords",
                columns: new[] { "PatientId", "AllergiesAllergyId", "AllergyId", "MedicalHistory", "Medications", "PatientName" },
                values: new object[] { 3, null, 3, "Very Healthy", "Pastile1212 lactoza", "Mark" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "PatientId",
                keyValue: 3);
        }
    }
}
