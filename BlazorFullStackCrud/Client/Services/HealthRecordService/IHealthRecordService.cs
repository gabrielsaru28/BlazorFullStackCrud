using BlazorFullStackCrud.Shared;

namespace BlazorFullStackCrud.Client.Services.HealthRecordService
{
    public interface IHealthRecordService
    {
        List<HealthRecord> Records { get; set; }
        
        List<Allergies> Allergies { get; set; }

        Task GetAllergies();
        Task GetHealthRecords();

        Task<HealthRecord> GetSingleHealthRecord(int id);


        Task CreateRecord(HealthRecord record);
        Task UpdateRecord(HealthRecord record);
        Task DeleteRecord(int id);  

    }
}
