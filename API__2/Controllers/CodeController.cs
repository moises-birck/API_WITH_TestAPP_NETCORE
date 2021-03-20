using Microsoft.AspNetCore.Mvc;

namespace API__2.Controllers
{
    [ApiController]
    public class CodeController : ControllerBase
    {
        public static string MyRepoUrl = "https://github.com/sesiom12/API_WITH_TDD_NETCORE";

        [Route("/ShowMeTheCode")]
        [HttpGet]
        public string ShowMeTheCode()
        {
            return MyRepoUrl;
        }
    }
}
