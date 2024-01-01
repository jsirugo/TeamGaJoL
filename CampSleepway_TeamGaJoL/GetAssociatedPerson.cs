using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class GetAssociatedPerson
    {
        public static Person AssociatedPerson(int Id)
        {
            using var context = new CampSleepawayContext();
            return context.Persons.Find(Id);
        }
    }
}
