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
    }
}
