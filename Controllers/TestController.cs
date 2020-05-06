using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult getUser()
        {
            return Ok(new {name = "Ali"});
        }
    }
}