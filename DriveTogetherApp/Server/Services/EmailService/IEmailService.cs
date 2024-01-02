using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Services.EmailService
{
    public interface IEmailService
    {
    Task SendEmailAsync(Email request);
    
    }
}
