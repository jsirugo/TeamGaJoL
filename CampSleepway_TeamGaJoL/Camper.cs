using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Camper : Person
    {

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

     
    }
}
