using MailKit.Net.Smtp;
using DriveTogetherApp.Shared.Model;
using MimeKit;

namespace DriveTogetherApp.Server.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(Email request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("noreply.drivetogether@gmail.com"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("noreply.drivetogether@gmail.com", "cuni vtqq kvpa hhab");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Task.CompletedTask;
        }
    }
}
