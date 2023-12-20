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
        public int CounselorId { get; set; }
        [Required]
        public int StartDate { get; set; }
        [Required]
        public int EndDate { get; set; }
    }
}
