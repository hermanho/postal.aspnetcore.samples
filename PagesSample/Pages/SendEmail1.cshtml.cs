using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postal;

namespace PagesSample.Pages
{
    public class SendEmail1 : PageModel
    {
        private readonly IEmailService _emailService;
        public SendEmail1(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task OnGet()
        {
            var requestPath = new RequestPath();
            requestPath.PathBase = Request.PathBase.ToString();
            requestPath.Host = Request.Host.ToString();
            requestPath.IsHttps = Request.IsHttps;
            requestPath.Scheme = Request.Scheme;
            requestPath.Method = Request.Method;

            var emailData = new Email("Pages/Emails/Testing1.cshtml");
            emailData.RequestPath = requestPath;
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";

            await _emailService.SendAsync(emailData);
        }
    }
}
