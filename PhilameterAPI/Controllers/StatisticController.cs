using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhilameterAPI.Controllers
{
    [Route("/Stat")]
    [Route("/Statistic")]
    public class StatisticController : Controller
    {
        [HttpGet]
        public IActionResult StatisticRoot()
        {
            var result = new
            {
                href = Url.Link(nameof(StatisticRoot), null),
                stat = "a stat"
            };

            return Ok(result);
        } 
    }
}
