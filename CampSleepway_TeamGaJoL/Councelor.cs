﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Councelor : Person
    {
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public int? CabinId { get; set; } // så att man kan se vilken cabin varje councelor ansvarar för
        //public Cabin? Cabin  { get; set; }// så att man kan se vilken cabin varje councelor ansvarar för
        public virtual ICollection<NextOfKin> NextOfKins { get; set; } // får ha next of kin ( så som tolkat av uppgiftsbeskrivningen)

    }
}
