using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class CabinManager
    {
        private readonly CampSleepawayContext context;

        public CabinManager(CampSleepawayContext dbContext)
        {
            context = dbContext;
        }

        public void AssignToCabin(Person person)
        {
            if (person is Camper camper)
            {
                AssignCamperToCabin(camper);
            }
            else if (person is Councelor councelor)
            {
                AssignCouncelorToCabin(councelor);
            }
        }

        private void AssignCamperToCabin(Camper camper)
        {
            
            var cabinWithoutCouncelor = context.Cabins.FirstOrDefault(c => c.Campers.Count < 4 && c.Councelor == null);

            if (cabinWithoutCouncelor != null)
            {
                cabinWithoutCouncelor.Campers.Add(camper);
                context.SaveChanges();
                Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} assigned to Cabin {cabinWithoutCouncelor.CabinId}.");
            }
            else
            {
                Console.WriteLine("No cabin available for camper assignment. A cabin without a councelor is needed.");
            }
        }

        private void AssignCouncelorToCabin(Councelor councelor)
        {
           
            var assignedCabin = context.Cabins.FirstOrDefault(c => c.Councelor != null && c.Councelor.Id == councelor.Id);

            if (assignedCabin != null)
            {
                Console.WriteLine($"Councelor {councelor.FirstName} {councelor.LastName} is already assigned to Cabin {assignedCabin.CabinId}.");
            }
            else
            {
               
                var cabinWithoutCouncelor = context.Cabins.FirstOrDefault(c => c.Councelor == null || c.Councelor.Id != councelor.Id);

                if (cabinWithoutCouncelor != null)
                {
                    cabinWithoutCouncelor.Councelor = councelor;
                    context.SaveChanges();
                    Console.WriteLine($"Councelor {councelor.FirstName} {councelor.LastName} assigned to Cabin {cabinWithoutCouncelor.CabinId}.");
                }
                else
                {
                    Console.WriteLine("All cabins are already assigned a councelor. Cannot assign councelor to a new cabin.");
                }
            }
        }
    }
}


