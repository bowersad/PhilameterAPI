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
        Task<Statistics> GetStatAsync(int Id, CancellationToken ct);

        Task<List<Statistics>> GetAllStatsAsync(CancellationToken ct);

        Task<int> AddStatAsync(int Id,
            string Name,
            string Description,
            decimal value,
            int categoryId,
            CancellationToken ct);

        Task<Categories> GetCategoryAsync(int Id, CancellationToken ct);

        Task<List<Categories>> GetAllCategoriesAsync(CancellationToken ct);
    }
}
