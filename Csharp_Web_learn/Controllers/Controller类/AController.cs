using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csharp_Web_learn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Create()
        //{


        //    return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        //}


    }
}
    