using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_HangfireSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {

        [HttpGet(Name = "Link1")]
        public OkResult Link1()
        {
            return Ok();
        }
    }
}
