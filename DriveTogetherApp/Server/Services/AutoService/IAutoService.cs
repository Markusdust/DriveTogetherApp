using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AutoService
{
    public interface IAutoService
    {
        //Task<ServiceResponse<Auto>> AddOrUpdateAuto(Auto auto);

        Task<ServiceResponse<List<Auto>>> GetAutosAsync();
        Task<ServiceResponse<List<Auto>>> GetAutosFromUserAsync(int userId);

        Task<ServiceResponse<Auto>> GetAutoAsync(int autoId);

    }
}
