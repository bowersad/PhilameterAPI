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
    [Route("/Stats")]
    public class StatsController : Controller
    {

        private IStatisticService _service;

        public StatsController(IStatisticService service)
        {
            _service = service;
        }

        [HttpGet("/Stats/{Id}")]
        public async Task<IActionResult> StatisticRoot(int Id, CancellationToken ct)
        {
            var result = await _service.GetStatAsync(Id, ct);
            if (result == null) return NotFound();

            return Ok(result);
        } 

        [HttpGet]
        public async Task<IActionResult> StatisticAll(CancellationToken ct)
        {
            var result = await _service.GetAllStatsAsync(ct);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("Stats/{Id}")]
        public async Task<IActionResult> AddStatistic(int Id,
            [FromBody]StatisticViewModel statistic,
            CancellationToken ct)
        {
            throw new NotImplementedException();            
        }
    }
}
