using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.BuchungService
{
    public interface IBuchungService
    {

        Task<ServiceResponse<Buchung>> CreateBuchung(Buchung buchung);
    }
}
