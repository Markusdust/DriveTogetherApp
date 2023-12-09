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
    }
}
