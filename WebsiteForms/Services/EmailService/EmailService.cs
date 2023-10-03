using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebsiteForms.Models.Services.Email;
using WebsiteForms.Repositories.Contracts;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebsiteForms.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmailService> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EmailService(IUnitOfWork unitOfWork, ILogger<EmailService> logger, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task SendEmailAsync(EmailData emailData)
        {
            try
            {
                var configuration = _unitOfWork.Configuration.SingleOrDefault(x => x.Key == emailData.Key);
                if (configuration == null)
                {
                    _logger.LogWarning($"Configuration with key {emailData.Key} not found");
                    throw new Exception("Internal email service error");
                }
                EmailSettings emailSettings = JsonConvert.DeserializeObject<EmailSettings>(configuration!.Value);
                var msg = await CreateMail(emailSettings, emailData);

                using (SmtpClient client = new SmtpClient())
                {
                    client.Credentials = new NetworkCredential(emailSettings.Account.From, emailSettings.Account.Password);
                    client.EnableSsl = true;
                    client.Port = Convert.ToInt32(emailSettings.Account.Port);
                    client.Host = emailSettings.Account.Host;
                    client.Send(msg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MailMessage> CreateMail(EmailSettings emailSettings, EmailData emailData)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(emailSettings.Account.From);
            msg.To.Add(emailData.MailTo);
            msg.Subject = emailSettings.Account.Subject;
            msg.SubjectEncoding = Encoding.UTF8;

            msg = await CreateBodyMail(emailSettings, emailData, msg);

            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;

            return msg;
        }

        public async Task<MailMessage> CreateBodyMail(EmailSettings emailSettings, EmailData emailData, MailMessage msg)
        {
            string Body = File.ReadAllText(Path.Combine(_hostingEnvironment.WebRootPath, "EmailTemplates", $"{emailSettings.Body.HtmlBody}.html"));
            for (int i = 0; i < emailData.Params.Length; i++)
            {
                Body = Body.Replace(emailSettings.Body.Params[i], emailData.Params[i]);
            }
            msg.Body = Body;

            return msg;
        }
    }
}
