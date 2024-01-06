using DriveTogetherApp.Client.Pages;
using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.BuchungService
{
    public class BuchungService : IBuchungService
    {
        private readonly DataContext _context;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        public BuchungService(DataContext context, IEmailService emailService, IAuthService authService)
        {
            _context = context;
            _emailService = emailService;
            _authService = authService;
        }
        public async Task<ServiceResponse<Buchung>> AddBuchung(Buchung buchung)
        {
            _context.Buchungen.Add(buchung);
            await _context.SaveChangesAsync();

            var userEmail = await _authService.GetUserEmailById(buchung.BenutzerId);

            var email = new Email
            {
                To = userEmail.Data,
                Subject = "Bestätigung Buchung",
                Body = "Lieber Nutzer Deine Buchung mit der FahrtId:" + buchung.FahrtId + "wurde erfolgreich getätigt."
            };
            await _emailService.SendEmailAsync(email);


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


                if (buchung.Storniert)
                {
                    var userEmail = await _authService.GetUserEmailById(buchung.BenutzerId);

                    var email = new Email
                    {
                        To = userEmail.Data,
                        Subject = "Bestätigung Stornierung",
                        Body = "Lieber Nutzer Deine Buchung mit der FahrtId: " + buchung.FahrtId + " wurde erfolgreich Storniert."
                    };
                    await _emailService.SendEmailAsync(email);
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

        public async Task<ServiceResponse<List<Buchung>>> GetBuchungByFahrtIdAsync(int FahrtId)
        {
            var serviceResponse = new ServiceResponse<List<Buchung>>();
            serviceResponse.Data = await _context.Buchungen.Where(b=>b.FahrtId == FahrtId).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<Buchung>> UpdateBuchungByFahrt(Buchung buchung)
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


                if (buchung.Storniert)
                {
                    var userEmail = await _authService.GetUserEmailById(buchung.BenutzerId);

                    var email = new Email
                    {
                        To = userEmail.Data,
                        Subject = "Bestätigung Stornierung",
                        Body = "Lieber Nutzer, leider wurde die Fahrt vom Fahrer/in storniert FahrtId:" + buchung.FahrtId + "Tut uns leid, wir hoffen es entstehen nicht zu grosse Umstände für dich"
                    };
                    await _emailService.SendEmailAsync(email);
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
