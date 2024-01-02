using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class Cabin
    {
        public int CabinId { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public List<Camper> Campers { get; set; }
        public Counselor? Counselor { get; set; }

        public Cabin()
        {
            Campers = new List<Camper>();
        }
    }
}
