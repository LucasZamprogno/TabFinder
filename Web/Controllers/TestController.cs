using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [ApiController]
    [Route("/")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("test")]
        public SavedSong Get()
        {
            return new SavedSong
            {
                artist = "Red Hot Chili Peppers",
                title = "Under The Bridge",
                album = "Blood Sugar Sex Magik",
                content = "Look for it online!"
            };
        }
    }
}
