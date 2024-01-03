using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CampSleepway_TeamGaJoL
{
    public class RemoveCamper
    {
        private readonly CampSleepawayContext context;

        public RemoveCamper(CampSleepawayContext dbContext)
        {
            context = dbContext;
        }

        public void RemoveCamperFromDatabase()
        {
            DisplayCampers();

            Console.Write("Enter Camper ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int camperId))
            {
                var camper = context.Campers.FirstOrDefault(c => c.Id == camperId);

                if (camper != null)
                {
                    var nextOfKins = context.NextOfKins.Where(n => n.CamperId == camperId).ToList();

                    var cabin = context.Cabins.Include(c => c.Campers).FirstOrDefault(c => c.Campers.Contains(camper));
                    //om campern fanns i en cabin: ↧
                    if (cabin != null)
                    {
                        cabin.Campers.Remove(camper);
                    }

                    // Ta bort relaterade NextOfKin
                    foreach (var nextOfKin in nextOfKins)
                    {
                        context.NextOfKins.Remove(nextOfKin);
                    }

                    context.Campers.Remove(camper);
                    context.SaveChanges();
                    Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} removed successfully.");
                }
                else
                {
                    Console.WriteLine("Camper not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Camper ID.");
            }
        }

        public void DisplayCampers()
        {
            var campers = context.Campers.ToList();
            Console.WriteLine("List of Campers:");
            foreach (var camper in campers)
            {
                Console.WriteLine($"Camper ID: {camper.Id}, Name: {camper.FirstName} {camper.LastName}");
            }
            Console.WriteLine();
        }
    }
}

