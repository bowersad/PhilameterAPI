using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhilameterAPI.Controllers
{
    [Route("/")]
    public class RootController : Controller
    {

        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var result = new
            {
                href = Url.Link(nameof(GetRoot), null),
                value1 = "value1"
            };

            return Ok(result);
            
        }
    }
}
