namespace Mail_Service_Training.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toAddress, string subject, string body, bool isBodyHtml = true);
    }
}
