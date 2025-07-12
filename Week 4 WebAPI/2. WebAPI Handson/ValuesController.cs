using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers // ← Replace with your actual project name
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"You posted: {value}");
        }
    }
}


