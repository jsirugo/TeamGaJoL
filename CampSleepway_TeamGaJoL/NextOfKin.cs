using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class NextOfKin : Person
    {
        public int NextOfKinId { get; set; }

        // Foreign key to Camper
        public int CamperId { get; set; }

        // Navigation property to Camper
      //  public virtual Camper Camper { get; set; }
    }
}
