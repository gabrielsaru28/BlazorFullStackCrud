namespace BlazorFullStackCrud.Server.Data
{
    /* 
     * Used to acces the data from the database 
     * We'll inject the data context to do that.
     */

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        // To see the data, we 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergies>().HasData(

                 new Allergies { AllergyId = 1, AllergyName = "Alergie la praf" },
                 new Allergies { AllergyId = 2, AllergyName = "Alergie la lactoza" }

                );


            modelBuilder.Entity<HealthRecord>().HasData(

                new HealthRecord
                {
                    PatientId = 1,
                    PatientName = "Ion",
                    MedicalHistory = "Healthy",
                    Medications = "Pastile test",
                    AllergyId = 1

                },

                new HealthRecord
                {
                    PatientId = 2,
                    PatientName = "John",
                    MedicalHistory = "Healthy",
                    Medications = "Pastile lactoza",
                    AllergyId = 2
                }
                 );

            base.OnModelCreating(modelBuilder);
        }


        // Very important - - The DbSets (Database sets)
        // Whenever you want to see an entity represented as a table in your db
        // You have to add the database set

        public DbSet<HealthRecord> HealthRecords { get; set; }

        public DbSet<Allergies> Allergies  { get; set; }

    }
}
