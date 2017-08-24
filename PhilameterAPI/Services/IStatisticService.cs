using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PhilameterAPI.Models;


namespace PhilameterAPI.Services
{
    public interface IStatisticService
    {
        Task<Statistic> GetStatAsync(int Id, CancellationToken ct);
    }
}
