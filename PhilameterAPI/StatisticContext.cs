﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhilameterAPI.Models;

namespace PhilameterAPI
{
    public class StatisticContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public StatisticContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<StatEntity> Stats { get; set; }

    }
}
