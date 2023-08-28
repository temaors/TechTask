namespace TechTask.Services.Messaging;

public interface IEmailSender
{
    void SendEmail(Message message);
}