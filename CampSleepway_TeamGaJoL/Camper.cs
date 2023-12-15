using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Camper : Person
    {
        public int CamperId { get; set; }
        public int StartDate {  get; set; }
        public int EndDate { get; set; }
        // Foreign key property
        public int CabinId { get; set; }
        // Reference navigation to Cabin
        public Cabin? Cabin { get; set; }
    }
}
