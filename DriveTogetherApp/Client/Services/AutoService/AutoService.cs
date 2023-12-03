namespace DriveTogetherApp.Client.Services.AutoService
{
    public class AutoService : IAutoService
    {
        List<Auto> Autos { get; set; }
        Task GetAutos();

    }
}
