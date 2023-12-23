using DriveTogetherApp.Client.Pages;
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

        public async Task<ServiceResponse<Fahrt>> GetFahrt(int fahrtId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Fahrt>>($"api/fahrt/{fahrtId}");
            return result;
        }

        public async Task<ServiceResponse<List<Fahrt>>> GetFahrtenByUserId(string userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Fahrt>>>($"api/fahrt/user/{userId}");
            return result;
        }

        public async Task<ServiceResponse<Fahrt>> UpdateFahrt(Fahrt fahrt)
        {
            var response = await _http.PutAsJsonAsync($"api/fahrt/{fahrt.FahrtId}", fahrt);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Fahrt>>();
        }
    }
    
}
