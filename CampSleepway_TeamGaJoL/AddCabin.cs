using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class AddCabin
    {
        private readonly CampSleepawayContext context;

        public AddCabin(CampSleepawayContext dbContext)
        {
            context = dbContext;
        }

        public void AddCabinToDatabase()
        {
            Console.Clear();
            try
            {
                var newCabin = new Cabin();

                Console.Write("Enter Cabin Name: ");
                newCabin.Name = Console.ReadLine();

                Console.Write("Enter Maximum Capacity: ");
                if (int.TryParse(Console.ReadLine(), out int maxCapacity))
                {
                    newCabin.MaxCapacity = maxCapacity;
                }

                context.Cabins.Add(newCabin);
                context.SaveChanges();

                Console.WriteLine($"Cabin '{newCabin.Name}' added successfully!");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }
}
