﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilameterAPI.Models
{
    public class Category : Resource
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
