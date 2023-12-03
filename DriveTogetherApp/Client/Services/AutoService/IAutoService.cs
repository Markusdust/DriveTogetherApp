using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Client.Services.AutoService
{
    public interface IAutoService
    {
        List<Auto> Autos { get; set; }
        Task GetAutos();
    }
}
