using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAA(int i)
        {
            if (i == 0)
                return Ok(88);
            else if (i == 1)
                return Ok(555);
            else
                return NotFound("臭傻逼i传错了");

        }
    }
}
