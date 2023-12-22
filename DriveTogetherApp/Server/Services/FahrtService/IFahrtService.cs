using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.FahrtService
{
    public interface IFahrtService
    {
        Task<ServiceResponse<Fahrt>> CreateFahrtAsync(Fahrt fahrt);
    }
}
