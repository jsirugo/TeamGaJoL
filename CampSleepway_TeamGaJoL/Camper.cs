﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Camper : Person
    {
        public int CamperId { get; set; }
        public int startDate {  get; set; }
        public int endDate { get; set; }

        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
