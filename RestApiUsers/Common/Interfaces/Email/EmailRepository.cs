namespace RestApiUsers.Common.Interfaces.Email;

public interface IMessageSender
{
    void SendMessage(string to, string subject, string body);
}