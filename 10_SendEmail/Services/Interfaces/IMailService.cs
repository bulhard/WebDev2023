using _10_SendEmail.Models.Email;

namespace _10_SendEmail.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}