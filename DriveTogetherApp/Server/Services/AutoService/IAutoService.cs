using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.AutoService
{
    public interface IAutoService
    {
        Task<ServiceResponse<List<Auto>>> GetAutosAsync();
          
    }
}
