using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AutoService
{
    public interface IAutoService
    {
        //Task<ServiceResponse<Auto>> AddOrUpdateAuto(Auto auto);
        Task<ServiceResponse<List<Auto>>> GetAutosAsync();
        Task<ServiceResponse<Auto>> GetAutoAsync(int autoId);
        Task<ServiceResponse<List<Auto>>> GetAutosByUserIdAsync(string userId);
        Task<ServiceResponse<Auto>> UpdateAuto(Auto auto);
    }
}
