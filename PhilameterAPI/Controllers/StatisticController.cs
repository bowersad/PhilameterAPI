﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhilameterAPI.Models;
using PhilameterAPI.Services;

namespace PhilameterAPI.Controllers
{
    [Route("/Stat")]
    [Route("/Statistic")]
    public class StatisticController : Controller
    {

        private IStatisticService _service;

        public StatisticController(IStatisticService service)
        {
            _service = service;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> StatisticRoot(int Id, CancellationToken ct)
        {
            var result = await _service.GetStatAsync(Id, ct);
            if (result == null) return NotFound();

            return Ok(result);
        } 
    }
}