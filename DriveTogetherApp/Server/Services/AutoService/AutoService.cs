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
        public async Task<ServiceResponse<List<Auto>>> GetAutosAsync()
        {
            var response = new ServiceResponse<List<Auto>>
            {
                Data= await _context.Autos.ToListAsync()
            };

            return response;
        }
    }
}
