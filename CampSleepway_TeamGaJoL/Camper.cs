using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Camper : Person
    {
        //Min age 6, max age 18
        public int CamperId { get; set; }
        public int startDate {  get; set; }
        public int endDate { get; set; }
        public int CabinId { get; set; }
        public Cabin Cabin { get; set; }
        public List<NextOfKin> NextOfKins { get; set; }

    }
}
