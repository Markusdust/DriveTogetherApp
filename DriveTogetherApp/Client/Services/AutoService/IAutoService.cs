using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.AutoService
{
    public interface IAutoService
    {
        List<Auto> Autos { get; set; }
        Task GetAutos();
        Task<ServiceResponse<List<Auto>>> GetAutosByUserId(string userId);
        Task<ServiceResponse<Auto>> GetAuto(int autoId);
    }
}
