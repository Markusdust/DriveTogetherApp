using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.BuchungService
{
    public interface IBuchungService
    {
        Task<ServiceResponse<Buchung>> AddBuchung(Buchung buchung);
        Task<ServiceResponse<List<Buchung>>> GetBuchungenByUserIdAsync(string userId);
        Task<ServiceResponse<Buchung>> UpdateBuchung(Buchung buchung);
    }
}
