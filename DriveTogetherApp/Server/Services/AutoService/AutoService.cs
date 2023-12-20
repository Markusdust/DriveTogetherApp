using DriveTogetherApp.Client.Pages;
using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AutoService
{
    public class AutoService : IAutoService
    {
        private readonly DataContext _context;
        public AutoService(DataContext context)
        {
            _context = context; 
        }

        public async Task<ServiceResponse<Auto>> AddAuto(Auto auto)
        {
            // Implementieren Sie die Logik zum Hinzufügen eines neuen Autos
            // Beispiel:



            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Auto> { Data = auto };
        }


        public async Task<ServiceResponse<Auto>> GetAutoAsync(int autoId)
        {
            var response = new ServiceResponse<Auto>();
            var auto = await _context.Autos.FindAsync(autoId);
            if (auto == null)
            {
                response.Success = false;
                response.Message = "Auto existiert nicht.";
            }
            else
            {
                response.Data = auto;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Auto>>> GetAutosAsync()
        {
            var response = new ServiceResponse<List<Auto>>
            {
                Data= await _context.Autos.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Auto>>> GetAutosByUserIdAsync(string userId)
        {
            var response = new ServiceResponse<List<Auto>>();
            var auto = await _context.Autos.Where(a => a.BenutzerId ==  int.Parse(userId)).ToListAsync();
            if (auto == null)
            {
                response.Success = false;
                response.Message = "Auto existiert nicht.";
            }
            else
            {
                response.Data = auto;
            }

            return response;
        }

        public async Task<ServiceResponse<Auto>> UpdateAuto(Auto auto)
        {
            var serviceResponse = new ServiceResponse<Auto>();
            try
            {
                Auto autoToUpdate = await _context.Autos.FindAsync(auto.AutoId);
                if (autoToUpdate == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Auto nicht gefunden.";
                    return serviceResponse;
                }

                // Aktualisieren der Eigenschaften, ausser BenutzerId und AutoId
                autoToUpdate.Marke = auto.Marke;
                autoToUpdate.Modell = auto.Modell;
                autoToUpdate.Farbe = auto.Farbe;
                autoToUpdate.Kennzeichen = auto.Kennzeichen;
                autoToUpdate.Baujahr = auto.Baujahr;
                autoToUpdate.Typ = auto.Typ;

                _context.Autos.Update(autoToUpdate);
                await _context.SaveChangesAsync();

                serviceResponse.Data = autoToUpdate;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
