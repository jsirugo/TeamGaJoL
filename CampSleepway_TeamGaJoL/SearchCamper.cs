using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class SearchCamper
    {
        private readonly CampSleepawayContext context;

        public SearchCamper(CampSleepawayContext dbContext)
        {
            context = dbContext;
        }
        public void DisplayCabins()
        {
            var cabins = context.Cabins.ToList();

            Console.WriteLine("\nCabins");
            foreach (var cabin in cabins)
            {
                Console.WriteLine($"Cabin ID: {cabin.CabinId}, Name: {cabin.Name}");
            }
            Console.WriteLine("Enter the ID of the cabin you want displayed");
            int cabinId = int.Parse(Console.ReadLine());

            var selectedCabin = context.Cabins.Include(c => c.Campers).Include(c => c.Counselor)
                                      .FirstOrDefault(c => c.CabinId == cabinId);

            if (selectedCabin != null)
            {

                Console.WriteLine($"Cabin ID: {selectedCabin.CabinId}, Name: {selectedCabin.Name}");
                Console.WriteLine($"CounselorID: {selectedCabin.Counselor.Id}, Name: {selectedCabin.Counselor.FirstName} {selectedCabin.Counselor.LastName}");

                if (selectedCabin.Campers.Any())
                {
                    Console.WriteLine("Occupants");

                    foreach (var camper in selectedCabin.Campers)
                    {
                        Console.WriteLine($" - CamperId: {camper.Id}. {camper.FirstName} {camper.LastName}");
                    }
                }
                else
                {
                    Console.WriteLine("No occupants!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Cabin ID");
            }
        }
        public void DisplayCounselors()
        {
            var counselors = context.Counselors.ToList();

            Console.WriteLine("\nCounselors");
            Console.WriteLine("Please write the ID number of the counselor to show cabin and campers");

            foreach (var counselor in counselors)
            {
                Console.WriteLine($"Counselor ID: {counselor.Id}. Name: {counselor.FirstName} {counselor.LastName}");
            }

            int counselorId = int.Parse(Console.ReadLine());

            var cabins = context.Cabins.Include(c => c.Campers).Include(c => c.Counselor)
                                   .Where(c => c.Counselor.Id == counselorId).ToList();

            var selectedCounselor = context.Counselors.FirstOrDefault(c => c.Id == counselorId);

            if (selectedCounselor != null)

            {
                foreach (var cabin in cabins)
                {
                    Console.WriteLine($"Cabin ID: {cabin.CabinId}, Name: {cabin.Name}");
                    Console.WriteLine($"CounselorID: {cabin.Counselor.Id}, Name: {cabin.Counselor.FirstName} {cabin.Counselor.LastName}");

                    if (cabin.Campers.Any())
                    {
                        Console.WriteLine("Occupants");

                        foreach (var camper in cabin.Campers)
                        {
                            Console.WriteLine($" - CamperId: {camper.Id}. {camper.FirstName} {camper.LastName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No occupants!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid counselor ID");
            }
        }
    }
}



