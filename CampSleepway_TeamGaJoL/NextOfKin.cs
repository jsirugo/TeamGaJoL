using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class NextOfKin : Person
    {
        public virtual Camper? Camper { get; set; } // måste vara ansluten till en camper
        public int? CouncelorId { get; set; } // FÅR vara ansluten till en camper, måste ej
        public virtual Councelor? Councelor { get; set; }// FÅR vara ansluten till en camper, måste ej

    }
}
