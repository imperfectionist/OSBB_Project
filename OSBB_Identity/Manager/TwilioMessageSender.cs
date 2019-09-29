using System.Threading.Tasks;
using System.Web.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace OSBB_Identity.Manager
{
    public interface ITwilioMessageSender
    {
        Task SendMessageAsync(string to, string body); 
    }

    public class TwilioMessageSender : ITwilioMessageSender
    {
        string accountSid = WebConfigurationManager.AppSettings["AccountSid"];
        string authToken = WebConfigurationManager.AppSettings["AuthToken"];
        string phonenumber = WebConfigurationManager.AppSettings["TwilioNumber"];

        public TwilioMessageSender()
        {
            TwilioClient.Init(accountSid, authToken);
        }

        public async Task SendMessageAsync(string to, string body)
        {
            await MessageResource.CreateAsync(new PhoneNumber(to), 
                                                from: new PhoneNumber(phonenumber), 
                                                body: body);
        }
    }
}