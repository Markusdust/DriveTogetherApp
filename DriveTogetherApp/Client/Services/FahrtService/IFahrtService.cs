using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.FahrtService
{
    public interface IFahrtService
    {
        Task<ServiceResponse<Fahrt>> CreateFahrt(Fahrt fahrt);

        Task<ServiceResponse<Fahrt>> GetFahrt(int fahrtId);

    }
}
