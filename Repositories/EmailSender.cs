using Microsoft.AspNetCore.Identity.UI.Services;

namespace Internet1_RentACar.Repositories
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
           return Task.CompletedTask;
        }
    }
}
