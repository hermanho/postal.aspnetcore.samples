using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Postal;

namespace PagesSample.Pages
{
    public class Preview2Model : PageModel
    {
        private readonly IEmailService _emailService;
        public Preview2Model(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetSend()
        {
            var emailData = new Email("~/Pages/Emails/Testing2.cshtml");
            emailData.CaptureHttpContext(HttpContext);
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";

            await _emailService.SendAsync(emailData);
            return new OkObjectResult("OK");
        }
    }
}
