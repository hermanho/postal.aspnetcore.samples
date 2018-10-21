using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Postal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace WebSample.Services.Email
{
    public interface IEmailSenderEnhance : IEmailSender
    {
        Task SendEmailAsync(MailMessage mailMessage);
        Task SendEmailAsync(Postal.Email emailData);
    }

    public class EmailSender : IEmailSenderEnhance
    {
        // Our private configuration variables
        private readonly EmailSenderOptions _emailOptions;
        private readonly IEmailService _emailService;
        private readonly IHostingEnvironment _env;

        // Get our parameterized configuration
        public EmailSender(IEmailService emailService,
            IEmailViewRender emailViewRenderer,
            IHostingEnvironment env,
            IOptions<EmailSenderOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
            _emailService = emailService;
            _env = env;
        }

        private SmtpClient CreateSmtpClient()
        {
            var client = new SmtpClient(_emailOptions.Host, _emailOptions.Port)
            {
                Credentials = new NetworkCredential(_emailOptions.UserName, _emailOptions.Password),
                EnableSsl = _emailOptions.EnableSSL
            };
            return client;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var client = CreateSmtpClient())
            {
                await client.SendMailAsync(
                    new MailMessage(_emailOptions.FromAddress, email, subject, htmlMessage) { IsBodyHtml = true }
                );
            }
        }

        public async Task SendEmailAsync(MailMessage mailMessage)
        {
            mailMessage.From = new MailAddress(_emailOptions.FromAddress);
            using (var client = CreateSmtpClient())
            {
                await client.SendMailAsync(mailMessage);
            }
        }

        public async Task SendEmailAsync(Postal.Email emailData)
        {            
            MailMessage message = await _emailService.CreateMailMessageAsync(emailData);
            message.From = new MailAddress(_emailOptions.FromAddress);
            await SendEmailAsync(message);
        }
    }
}
