using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.HealthRecordService
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public HealthRecordService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<HealthRecord> Records { get; set; } = new List<HealthRecord>();
        
        public List<Allergies> Allergies { get; set; } = new List<Allergies>();
        public HttpClient Http { get; }

        public async Task CreateRecord(HealthRecord record)
        {
            // result is an HttpResponseMessage ( we do not get the list of the healthrecords directly)
            var result = await _http.PostAsJsonAsync("api/healthrecord", record);
            await SetRecords(result);
        }

        private async Task SetRecords(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<HealthRecord>>();
            Records = response;
            _navigationManager.NavigateTo("healthrecord");
        }

        public async Task DeleteRecord(int id)
        {
            // result is an HttpResponseMessage ( we do not get the list of the healthrecords directly)
            var result = await _http.DeleteAsync($"api/healthrecord/{id}");
           // var response = await result.Content.ReadFromJsonAsync<List<HealthRecord>>();
            await SetRecords(result);
        }

        public async Task GetAllergies()
        {
            var result = await _http.GetFromJsonAsync<List<Allergies>>("api/healthrecord/allergies");
            if (result != null)
                Allergies = result;

        }

        public async Task GetHealthRecords()
        {
            var result = await _http.GetFromJsonAsync<List<HealthRecord>>("api/healthrecord");
            if (result != null)
                Records = result;

        }

        public async Task<HealthRecord> GetSingleHealthRecord(int id)
        {
            var result = await _http.GetFromJsonAsync<HealthRecord>($"api/healthrecord/{id}");
            if (result != null)
                return result;
            throw new Exception("HealthRecord not found!");
        }

        public async Task UpdateRecord(HealthRecord record)
        {
            // result is an HttpResponseMessage ( we do not get the list of the healthrecords directly)
            var result = await _http.PutAsJsonAsync($"api/healthrecord{record.PatientId}", record);
            //var response = await result.Content.ReadFromJsonAsync<List<HealthRecord>>();
            await SetRecords(result);
        }
    }
}
