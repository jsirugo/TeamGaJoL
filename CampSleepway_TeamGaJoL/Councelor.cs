using System;
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
        public virtual ICollection<NextOfKin> NextOfKins { get; set; } // får ha next of kin ( så som tolkat av uppgiftsbeskrivningen)

    }
}
