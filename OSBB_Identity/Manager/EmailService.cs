using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;

namespace OSBB_Identity.Manager
{
    public class EmailService : IIdentityMessageService
    {
        public object HttpUtility { get; private set; }

        public Task SendAsync(IdentityMessage message)
        {
            //string html = "Будь-ласка, підтвердіть, що ви зареєструвалися на нашому сайті натиснувши це посилання: " + message.Body;

            //Credentials
            var credentialUserName = WebConfigurationManager.AppSettings["EmailUsername"];
            var sentFrom = WebConfigurationManager.AppSettings["EmailUsername"];
            var pwd = WebConfigurationManager.AppSettings["EmailPassword"];

            //Configure the client
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            //Create credentials
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(credentialUserName, pwd);

            client.EnableSsl = true;
            client.Credentials = credentials;

            //Create the message
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body
            };

            //mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            //Send
            return client.SendMailAsync(mail);
        }
    }
}