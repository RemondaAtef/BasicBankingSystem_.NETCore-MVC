namespace Basic_Banking_System.Services
{
    public interface IMailService
    {
        void SendMessage(string to, string subject, string body);
    }
}