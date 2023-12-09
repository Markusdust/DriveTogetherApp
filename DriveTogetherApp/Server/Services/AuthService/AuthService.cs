using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public Task<ServiceResponse<int>> Register(Benutzer benutzer, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
