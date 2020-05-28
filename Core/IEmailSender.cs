using System.Threading.Tasks;

namespace Core
{
    public interface IEmailSender
    {
        Task SendMailAsync(Message message);
    }
}