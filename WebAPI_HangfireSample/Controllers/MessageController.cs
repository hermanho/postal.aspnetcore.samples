using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Postal;

namespace WebAPI_HangfireSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IEmailService _emailService;

        public MessageController(
            ILogger<MessageController> logger,
            IEmailService emailService
            )
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpGet(Name = "SendEmail")]
        public OkResult SendEmail()
        {
            var emailData = new Email("Testing1");
            emailData.ViewData["to"] = "hello@example.com";
            emailData.ViewData["Name"] = "Sam";
            emailData.CaptureHttpContext(HttpContext);

            BackgroundJob.Enqueue<IEmailService>(x => x.SendAsync(emailData));
            return Ok();
        }
    }
}
