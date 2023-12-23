using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.FahrtService
{
    public class FahrtService : IFahrtService
    {
        private readonly DataContext _context;

        public FahrtService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Fahrt>> CreateFahrtAsync(Fahrt fahrt)
        {
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
