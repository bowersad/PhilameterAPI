using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhilameterAPI.Services;
using System.Threading;

namespace PhilameterAPI.Controllers
{
    [Route("/Category")]
    public class CategoryController : Controller
    {
        private IStatisticService _service;

        public CategoryController(IStatisticService service)
        {
            _service = service;
        }

        [HttpGet("/Category/{Id}")]
        public async Task<IActionResult> GetCategory(int Id, CancellationToken ct)
        {
            var result = await _service.GetCategoryAsync(Id, ct);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAll(CancellationToken ct)
        {
            var result = await _service.GetAllCategoriesAsync(ct);
            if (result == null) return NotFound();

            return Ok(result);
        }

       
    }
}
