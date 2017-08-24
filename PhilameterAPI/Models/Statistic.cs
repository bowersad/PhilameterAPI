using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilameterAPI.Models
{
    public class Statistic : Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public decimal Value { get; set; }

        public StatPeriod Frequency { get; set; }
    }

    public enum StatPeriod { daily, weekly, monthly, yearly }
}
