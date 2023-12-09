using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<int>> Register(Benutzer benutzer, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Benutzers.AnyAsync(benutzer => benutzer.Email.ToLower()
                .Equals(email.ToLower())))
            {
                return true;
            }
            return false;  
        }
    }
}
