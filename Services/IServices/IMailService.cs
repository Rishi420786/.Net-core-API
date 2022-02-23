using Common.CommonUtility;

namespace ServiceLayer.IServices
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
