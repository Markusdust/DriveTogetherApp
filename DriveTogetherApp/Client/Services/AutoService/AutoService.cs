using DriveTogetherApp.Shared;
using DriveTogetherApp.Shared.Model;
using System.Data.SqlTypes;
using System.Globalization;
using System.Net.Http.Json;

namespace DriveTogetherApp.Client.Services.AutoService
{
    public class AutoService : IAutoService
    {
        private readonly HttpClient _http;
        public AutoService(HttpClient http)
        {
            _http = http;
        }
        public List<Auto> Autos { get; set; } = new List<Auto>();

        public async Task<ServiceResponse<Auto>> CreateAuto(Auto auto)
        {
            var response = await _http.PostAsJsonAsync("api/auto", auto);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Auto>>();
        }

        public async Task<ServiceResponse<Auto>> GetAuto(int autoId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Auto>>($"api/auto/{autoId}");
            return result;
        }

        public async Task  GetAutos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Auto>>>("api/auto");
            if (result != null && result.Data != null)
            Autos = result.Data;
        }

        public async Task<ServiceResponse<List<Auto>>> GetAutosByUserId(string userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Auto>>>($"api/auto/user/{userId}");
            return result;
        }

        public async Task<ServiceResponse<Auto>> UpdateAuto(Auto auto)
        {
            var response = await _http.PutAsJsonAsync($"api/auto/{auto.AutoId}", auto);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Auto>>();
        }
    }
}
