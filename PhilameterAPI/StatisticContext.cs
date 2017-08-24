using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhilameterAPI.Models;

namespace PhilameterAPI
{
    public class StatisticContext : DbContext
    {
        public StatisticContext( DbContextOptions options) : base(options)
        {

        }

        public DbSet<StatisticEntity> Statistics { get; set; }

    }
}
