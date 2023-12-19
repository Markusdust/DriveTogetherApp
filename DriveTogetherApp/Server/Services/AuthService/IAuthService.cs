using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(Benutzer benutzer, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(string email, string password);

        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
    }
}
