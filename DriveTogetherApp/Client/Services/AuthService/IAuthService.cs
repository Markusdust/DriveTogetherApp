using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(BenutzerRegister request);

        Task<ServiceResponse<string>> Login(BenutzerLogin request);
        Task<ServiceResponse<bool>> ChangePassword(BenutzerChangePassword request);
    }
}
