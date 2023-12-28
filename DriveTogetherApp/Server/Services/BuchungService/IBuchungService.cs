using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.BuchungService
{
    public interface IBuchungService
    {
        Task<ServiceResponse<Buchung>> AddBuchung(Buchung buchung);
    }
}
