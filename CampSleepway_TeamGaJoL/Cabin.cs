using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Cabin 
    {

        public required int CounselorId { get; set; }    
        public int CabinId {get; set; }

        public List<Camper>? Campers { get; set; }
    }
}
