using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PhilameterAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace PhilameterAPI.Services
{
    public class DefaultStatisticService : IStatisticService
    {
        private StatisticContext _context;

        public DefaultStatisticService(StatisticContext context)
        {
            _context = context;
        }

        public async Task<Statistics> GetStatAsync(int Id, CancellationToken ct)
        {
            var entity = await _context.Stats.SingleOrDefaultAsync(r => r.Id == Id, ct);
            if (entity == null) return null;

            return Mapper.Map<Statistics>(entity);
        }

        public async Task<List<Statistics>> GetAllStatsAsync(CancellationToken ct)
        {
            List<StatEntity> entity;
            entity = await _context.Stats.ToListAsync(ct);

            if (entity == null) return null;

            var result = Mapper.Map<List<Statistics>>(entity);
            //Mapper.AssertConfigurationIsValid();

            return result;

        }
    }
}
