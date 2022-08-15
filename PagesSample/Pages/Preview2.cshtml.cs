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
        //private readonly IRouter _router;

        public Preview2Model()
        {
            //_router = router;
        }

        public IActionResult OnGet()
        {
            var requestPath = new RequestPath();
            requestPath.PathBase = Request.PathBase.ToString();
            requestPath.Host = Request.Host.ToString();
            requestPath.IsHttps = Request.IsHttps;
            requestPath.Scheme = Request.Scheme;
            requestPath.Method = Request.Method;

            var emailData = new Email("Pages/Emails/Testing2.cshtml");
            emailData.RequestPath = requestPath;
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";

            return new EmailViewResult(emailData);
            //return Page();
        }
    }
}
