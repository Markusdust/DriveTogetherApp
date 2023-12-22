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
    }
}
