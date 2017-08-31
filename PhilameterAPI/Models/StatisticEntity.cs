using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilameterAPI.Models
{
    public class StatEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category_Id { get; set; }

        public double Stat { get; set; }

        //public int StatPeriod { get; set; }


    }
}
