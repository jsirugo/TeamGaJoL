﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Councelor : Person
    {
        public int CouncelorId { get; set; }

        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
