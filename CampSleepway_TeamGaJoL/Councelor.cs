using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Counselor : Person
    {
        //Min age 18, must relate one to one cabin per councelor
        public int CouncelorId { get; set; }
        public int CabinId { get; set; }
        public Cabin Cabin { get; set;}
    }
}
