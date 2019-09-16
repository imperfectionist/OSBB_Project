using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;

namespace OSBB_Identity.Manager
{
    public class SmsService : IIdentityMessageService
    {
        private readonly TwilioMessageSender messageSender;

        public SmsService()
        {
            this.messageSender = new TwilioMessageSender();
        }

        public async Task SendAsync(IdentityMessage message)
        {
            await messageSender.SendMessageAsync(message.Destination, message.Body);
        }
    }
}