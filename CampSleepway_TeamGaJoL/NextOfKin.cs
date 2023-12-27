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
        public int? CamperId { get; set; } // måste sättas till null av någon anledning, löses med kod i programmet så det måste vara kopplat.
        public virtual Camper? Camper { get; set; } // måste vara ansluten till en camper
        public int? CouncelorId { get; set; } // FÅR vara ansluten till en councelor, måste ej
        public virtual Councelor? Councelor { get; set; }// FÅR vara ansluten till en coucelor, måste ej

    }
}
