using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebSample.Models;
using WebSample.Services.Email;

namespace WebSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSenderEnhance _emailSender;

        public HomeController(IEmailSenderEnhance emailSender)
        {
            _emailSender = emailSender;
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
            var requestPath = new Postal.RequestPath();
            requestPath.PathBase = Request.PathBase.ToString();
            requestPath.Host = Request.Host.ToString();
            requestPath.IsHttps = Request.IsHttps;
            requestPath.Scheme = Request.Scheme;
            requestPath.Method = Request.Method;

            var emailData = new Postal.Email("Testing1");
            emailData.RequestPath = requestPath;
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            
            await _emailSender.SendEmailAsync(emailData);
            return View();
        }

        public async Task<IActionResult> SendEmail2()
        {
            var requestPath = new Postal.RequestPath();
            requestPath.PathBase = Request.PathBase.ToString();
            requestPath.Host = Request.Host.ToString();
            requestPath.IsHttps = Request.IsHttps;
            requestPath.Scheme = Request.Scheme;
            requestPath.Method = Request.Method;

            var emailData = new Postal.Email("~/Views/AnotherFolder/Testing2.cshtml");
            emailData.RequestPath = requestPath;
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            
            await _emailSender.SendEmailAsync(emailData);
            return View();
        }
    }
}
