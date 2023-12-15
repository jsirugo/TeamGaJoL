using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class NextOfKin : Person
    {
        public required int  CamperId { get; set; }
        public required Camper Camper { get; set; }  //reference navigation to camper
    }
}
