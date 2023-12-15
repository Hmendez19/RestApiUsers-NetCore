using Newtonsoft.Json;
using RestApiUsers.Common.Interfaces.Email;

namespace RestApiUsers.Modules.Users.Infrastructure.Adapters;

public class GmailMessageSender:IMessageSender
{
    public void SendMessage(string to, string subject, string body)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[Logger::GmailMessageSender] => { JsonConvert.SerializeObject(new { to, subject, body })}");
        Console.ResetColor();
    }
}