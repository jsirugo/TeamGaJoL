﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Cabin
    {
        public int CabinId { get; set; }
        public List<Camper> Campers { get; set; }
        public Councelor Councelor { get; set; }
    }
}
