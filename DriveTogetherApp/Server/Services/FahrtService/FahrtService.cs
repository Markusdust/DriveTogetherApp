using DriveTogetherApp.Client.Pages;
using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.FahrtService
{
    public class FahrtService : IFahrtService
    {
        private readonly DataContext _context;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private readonly IBuchungService _buchungService;

        public FahrtService(DataContext context, IEmailService emailService, IAuthService authService, IBuchungService buchungService)
        {
            _context = context;
            _emailService = emailService;
            _authService = authService;
            _buchungService = buchungService;
        }

        public async Task<ServiceResponse<Fahrt>> CreateFahrtAsync(Fahrt fahrt)
        {
            
            var userEmail = await _authService.GetUserEmailById(fahrt.BenutzerId);

            var email = new Email
            {
                To = userEmail.Data,
                Subject = "Bestätigung Fahrt erstellt",
                Body = "Lieber Nutzer Deine Fahrt mit der FahrtId: " + fahrt.FahrtId + " wurde erfolgreich erstelllt."
            };
            await _emailService.SendEmailAsync(email);

            _context.Fahrten.Add(fahrt);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Fahrt> { Data = fahrt };
        }

        public async Task<ServiceResponse<Fahrt>> GetFahrtAsync(int fahrtId)
        {
            var response = new ServiceResponse<Fahrt>();
            var fahrt = await _context.Fahrten
                                    .Include(f => f.AbfahrtAdresse)
                                    .Include(f => f.AnkunftAdresse)
                                    .FirstOrDefaultAsync(f => f.FahrtId == fahrtId);

            if (fahrt == null)
            {
                response.Success = false;
                response.Message = "Fahrt existiert nicht.";
            }
            else
            {
                response.Data = fahrt;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Fahrt>>> GetFahrtenByUserIdAsync(string userId)
        {
            var response = new ServiceResponse<List<Fahrt>>();
            var fahrt = await _context.Fahrten
                                .Where(f => f.BenutzerId == int.Parse(userId))
                                .Include(f => f.AbfahrtAdresse)
                                .Include(f => f.AnkunftAdresse)
                                .ToListAsync();
            if (fahrt == null)
            {
                response.Success = false;
                response.Message = "Fahrt existiert nicht.";
            }
            else
            {
                response.Data = fahrt;
            }

            return response;
        }

        public async Task<ServiceResponse<Fahrt>> UpdateFahrt(Fahrt fahrt)
        {
            var serviceResponse = new ServiceResponse<Fahrt>();
            try
            {
                var fahrtToUpdate = await _context.Fahrten.FindAsync(fahrt.FahrtId);
                if (fahrtToUpdate == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Fahrt existiert nicht.";
                    return serviceResponse;
                }

                fahrtToUpdate.AutoId= fahrt.AutoId;
                fahrtToUpdate.Startdatum = fahrt.Startdatum;
                fahrtToUpdate.AnzahlSitzplaetze = fahrt.AnzahlSitzplaetze;
                fahrtToUpdate.Preis = fahrt.Preis;
                fahrtToUpdate.Storniert = fahrt.Storniert;
                fahrtToUpdate.AbfahrtAdresse = fahrt.AbfahrtAdresse;
                fahrtToUpdate.AnkunftAdresse = fahrt.AnkunftAdresse;

                if (fahrt.Storniert)
                {
                    var userEmail = await _authService.GetUserEmailById(fahrt.BenutzerId);

                    var email = new Email
                    {
                        To = userEmail.Data,
                        Subject = "Bestätigung Stornierung",
                        Body = "Lieber Nutzer Deine Fahrt mit der FahrtId:" + fahrt.FahrtId + "wurde erfolgreich Storniert."
                    };
                    await _emailService.SendEmailAsync(email);

                    //Buchungen Stornieren falls jemand bereits angemeldet ist
                    var buchugen = await _buchungService.GetBuchungByFahrtIdAsync(fahrt.FahrtId);
                    if (buchugen.Data.Count >0)
                    {
                        foreach (var buchung in buchugen.Data)
                        {
                            buchung.Storniert = true;
                            await _buchungService.UpdateBuchungByFahrt(buchung);
                        }
                    }
                }

                _context.Fahrten.Update(fahrtToUpdate);
                await _context.SaveChangesAsync();

                serviceResponse.Data = fahrtToUpdate;
                serviceResponse.Message = "Fahrt erfolgreich aktualisiert.";
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
