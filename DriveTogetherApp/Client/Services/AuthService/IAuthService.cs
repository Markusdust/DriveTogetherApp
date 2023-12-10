using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(BenutzerRegister request);
    }
}
