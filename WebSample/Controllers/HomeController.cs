using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using Postal;
using Postal.AspNetCore;
using WebSample.Models;

namespace WebSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SendEmail1()
        {
            var emailData = new Email("Testing1");
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            emailData.CaptureHttpContext(HttpContext);

            await _emailService.SendAsync(emailData);
            return View();
        }

        public async Task<IActionResult> SendEmail2()
        {
            var emailData = new Email("~/Views/AnotherFolder/Testing2.cshtml");
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            emailData.CaptureHttpContext(HttpContext);

            await _emailService.SendAsync(emailData);
            return View();
        }

        public async Task<IActionResult> SendEmail3()
        {
            var emailData = new Email("Testing3");
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            emailData.CaptureHttpContext(HttpContext);

            await _emailService.SendAsync(emailData);
            return View();
        }

        public IActionResult PerviewEmail1()
        {
            var requestPath = new RequestPath();
            requestPath.PathBase = Request.PathBase.ToString();
            requestPath.Host = Request.Host.ToString();
            requestPath.IsHttps = Request.IsHttps;
            requestPath.Scheme = Request.Scheme;
            requestPath.Method = Request.Method;

            var emailData = new Email("Testing1");
            emailData.RequestPath = requestPath;
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";

            return new EmailViewResult(emailData);
        }
    }
}
