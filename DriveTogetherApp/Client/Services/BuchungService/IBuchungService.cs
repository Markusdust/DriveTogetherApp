using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.BuchungService
{
    public interface IBuchungService
    {
        Task<ServiceResponse<Buchung>> CreateBuchung(Buchung buchung);
        Task<ServiceResponse<List<Buchung>>> GetBuchungenByUserId(string userId);
        Task<ServiceResponse<Buchung>> UpdateBuchung(Buchung buchung);
    }
}
