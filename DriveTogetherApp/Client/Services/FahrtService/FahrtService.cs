using DriveTogetherApp.Shared.Model;
using System.Net.Http.Json;

namespace DriveTogetherApp.Client.Services.FahrtService
{
    public class FahrtService : IFahrtService
    {
        private readonly HttpClient _http;
        public FahrtService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<Fahrt>> CreateFahrt(Fahrt fahrt)
        {
            var response = await _http.PostAsJsonAsync("api/fahrt", fahrt);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Fahrt>>();
        }
    }
}
