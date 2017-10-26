using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilameterAPI.Models
{
    public class Statistics : Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Stat { get; set; }

        public StatPeriod Frequency { get; set; }

        public string PanelClass { get; set; }

        public string FontAwesomeIcon { get; set; }
    }

    public enum StatPeriod { daily, weekly, monthly, yearly }

}
