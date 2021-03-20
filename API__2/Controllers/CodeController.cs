using Microsoft.AspNetCore.Mvc;

namespace API__2.Controllers
{
    [ApiController]
    public class CodeController : ControllerBase
    {
        public static string MyRepoUrl = "url";

        [Route("/ShowMeTheCode")]
        [HttpGet]
        public string ShowMeTheCode()
        {
            return MyRepoUrl;
        }
    }
}
