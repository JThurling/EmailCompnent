using System.Threading.Tasks;

namespace Core
{
    public interface IEmailSender
    {
        //Contact Us Email Interface
        Task SendMailAsync(ContactUsMessage message);
        
        //Help and Donation Page
        Task SendMailAsync(HelpAndDonationMessage message);
        
        //Broker Page
        Task SendMailAsync(BrokerMessage message);
        
        //Intermediary Broker
        Task SendMailAsync(IntermediaryMessage message);
        
        //ServiceProvider
        Task SendMailAsync(ServiceProviderMessage message);
    }
}