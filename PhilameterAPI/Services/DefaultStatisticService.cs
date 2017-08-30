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
    }
}
