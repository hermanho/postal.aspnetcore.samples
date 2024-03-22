using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postal;

namespace PagesSample.Pages
{
    public class Preview1Model : PageModel
    {
        private readonly IEmailService _emailService;
        public Preview1Model(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async void OnGet()
        {
            var emailData = new Email("~/Pages/Emails/Testing1.cshtml");
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            emailData.CaptureHttpContext(HttpContext);

            await _emailService.SendAsync(emailData);
        }
    }
}
