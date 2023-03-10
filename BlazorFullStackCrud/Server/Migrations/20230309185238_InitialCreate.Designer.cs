// <auto-generated />
using BlazorFullStackCrud.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorFullStackCrud.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230309185238_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorFullStackCrud.Shared.Allergies", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyId"));

                    b.Property<string>("AllergyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergyId");

                    b.ToTable("Allergies");

                    b.HasData(
                        new
                        {
                            AllergyId = 1,
                            AllergyName = "Alergie la praf"
                        },
                        new
                        {
                            AllergyId = 2,
                            AllergyName = "Alergie la lactoza"
                        },
                        new
                        {
                            AllergyId = 3,
                            AllergyName = "Alergie la capsuni"
                        });
                });

            modelBuilder.Entity("BlazorFullStackCrud.Shared.HealthRecord", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.HasIndex("AllergyId");

                    b.ToTable("HealthRecords");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            AllergyId = 1,
                            MedicalHistory = "Healthy",
                            Medications = "Pastile test",
                            PatientName = "Ion"
                        },
                        new
                        {
                            PatientId = 2,
                            AllergyId = 2,
                            MedicalHistory = "Healthy",
                            Medications = "Pastile lactoza",
                            PatientName = "John"
                        },
                        new
                        {
                            PatientId = 3,
                            AllergyId = 3,
                            MedicalHistory = "Very Healthy",
                            Medications = "Pastile1212 lactoza",
                            PatientName = "Mark"
                        });
                });

            modelBuilder.Entity("BlazorFullStackCrud.Shared.HealthRecord", b =>
                {
                    b.HasOne("BlazorFullStackCrud.Shared.Allergies", "Allergies")
                        .WithMany("HealthRecords")
                        .HasForeignKey("AllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergies");
                });

            modelBuilder.Entity("BlazorFullStackCrud.Shared.Allergies", b =>
                {
                    b.Navigation("HealthRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
