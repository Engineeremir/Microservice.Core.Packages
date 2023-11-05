namespace Microservice.Core.Packages.Mailing;

public interface IMailService
{
    void SendMail(Mail mail);
}
