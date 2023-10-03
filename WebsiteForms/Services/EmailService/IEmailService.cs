using WebsiteForms.Models.Services.Email;

namespace WebsiteForms.Services.EmailService
{
    public interface IEmailService
    {
       Task SendEmailAsync(EmailData emailData);
    }
}
