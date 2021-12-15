using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace IdentityManager.Services
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MailJetOptions _mailjetOptions;

        public MailJetEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailjetOptions = _configuration.GetSection("MailJet").Get<MailJetOptions>();

            MailjetClient client = new MailjetClient(_mailjetOptions.ApiKey, _mailjetOptions.SecretKey);

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            };
          

            // construct your email with builder
            var emailmessage = new TransactionalEmailBuilder()
                   .WithFrom(new SendContact("mvisanu1@protonmail.com"))
                   .WithSubject(subject)
                   .WithHtmlPart(htmlMessage)
                   .WithTo(new SendContact(email))
                   .Build();

            // invoke API to send email
            var response = await client.SendTransactionalEmailAsync(emailmessage);

           if (response.Messages.Length == 1)
            {
                //successful

            }

        }
    }

}


