using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilameterAPI.Models
{
    public class StatisticEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public int Value { get; set; }

        public int StatPeriod { get; set; }


    }
}
