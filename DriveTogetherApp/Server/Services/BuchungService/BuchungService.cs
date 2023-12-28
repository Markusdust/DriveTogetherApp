using DriveTogetherApp.Client.Pages;
using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.BuchungService
{
    public class BuchungService : IBuchungService
    {
        private readonly DataContext _context;
        public BuchungService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Buchung>> AddBuchung(Buchung buchung)
        {
            _context.Buchungen.Add(buchung);
            await _context.SaveChangesAsync();


            return new ServiceResponse<Buchung> { Data = buchung };
        }

        public async Task<ServiceResponse<List<Buchung>>> GetBuchungenByUserIdAsync(string userId)
        {
            var response = new ServiceResponse<List<Buchung>>();
            var buchung = await _context.Buchungen.Where(b => b.BenutzerId == int.Parse(userId)).ToListAsync();

            if (buchung == null)
            {
                response.Success = false;
                response.Message = "Buchung existiert nicht.";
            }
            else
            {
                response.Data = buchung;
            }

            return response;
        }

        public async Task<ServiceResponse<Buchung>> UpdateBuchung(Buchung buchung)
        {
            var serviceResponse = new ServiceResponse<Buchung>();
            try
            {
                var buchungToUpdate = await _context.Buchungen.FindAsync(buchung.BuchungId);
                if (buchungToUpdate == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Buchung existiert nicht.";
                    return serviceResponse;
                }
                buchungToUpdate.Buchungsdatum = buchung.Buchungsdatum;
                buchungToUpdate.FahrtId = buchung.FahrtId;
                buchungToUpdate.BenutzerId = buchung.BenutzerId;
                buchungToUpdate.Storniert = buchung.Storniert;

                _context.Buchungen.Update(buchungToUpdate);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Ein Fehler ist aufgetreten: {ex.Message}";
            }

            return serviceResponse;
        }
    }
}
