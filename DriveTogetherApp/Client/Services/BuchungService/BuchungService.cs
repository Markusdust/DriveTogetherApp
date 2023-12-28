using DriveTogetherApp.Client.Pages;
using DriveTogetherApp.Shared.Model;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DriveTogetherApp.Client.Services.BuchungService
{
    public class BuchungService : IBuchungService
    {
        private readonly HttpClient _http;
        public BuchungService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<Buchung>> CreateBuchung(Buchung buchung)
        {
            var response = await _http.PostAsJsonAsync("api/buchung", buchung);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Buchung>>();
        }
    }
}
