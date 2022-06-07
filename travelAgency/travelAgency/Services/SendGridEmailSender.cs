using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace travelAgency.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        //private readonly ILogger _logger; 
        public SendGridEmailSender(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _configuration["SendGridApiKey"];

            var client = new SendGridClient(apiKey);

            var message = new SendGridMessage()
            {
                From = new EmailAddress("Buri_dk90@student.itstep.org", "Vlad"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);
            var response = await client.SendEmailAsync(message);

            //if (response.IsSuccessStatusCode)
            //    _logger.LogInformation("Email send");
            //else
            //    _logger.LogInformation("Error");
        }
    }
}
