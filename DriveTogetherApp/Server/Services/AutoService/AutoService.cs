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

        //public async Task<ServiceResponse<Auto>> AddOrUpdateAuto(Auto auto)
        //{
            
        //}

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

        public async Task<ServiceResponse<List<Auto>>> GetAutosFromUserAsync(int userId)
        {
            var user = await _context.Benutzers.FindAsync(userId);
            var response = new ServiceResponse<List<Auto>>
            {
                Data = await _context.Autos.Where(a => a.AutoId ==1).ToListAsync()
            };

            return response;
        }
    }
}
