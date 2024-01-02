using Microsoft.EntityFrameworkCore;
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

        public void DisplayCabinOccupants()
        {
            var cabins = context.Cabins.Include(c => c.Campers).Include(c => c.Counselor).ToList();
            var nextOfKins = context.NextOfKins.Include(c => c.Camper).ToList();
            Console.WriteLine("\nCabins:");
            foreach (var cabin in cabins)
            {
                Console.WriteLine($"Cabin ID: {cabin.CabinId}, Name: {cabin.Name}");

                if (cabin.Counselor != null)
                {
                    Console.WriteLine($"Counselor: {cabin.Counselor.FirstName} {cabin.Counselor.LastName}");
                }

                if (cabin.Campers.Any())
                {

                    Console.WriteLine("Occupants:");
                    foreach (var camper in cabin.Campers)
                    {

                        var nextOfKin = nextOfKins.FirstOrDefault(n => n.CamperId == camper.Id);

                        Console.WriteLine($" - CamperId: {camper.Id}. {camper.FirstName} {camper.LastName}");

                        if (nextOfKin != null)
                        {
                            Console.WriteLine($"   NextOfKin associated to {camper.FirstName}: {nextOfKin.FirstName} {nextOfKin.LastName}");
                        }

                    }
                   
                }
                else
                {
                    Console.WriteLine("No occupants!");
                }

            }
            
        }

        public void PersonSelecter()
        {

            Console.WriteLine("\n Who do you want to assign to a cabin?");
            var persons = context.Persons.ToList();

            foreach (var person in persons)
            {
                if (person is Counselor counselor) { Console.WriteLine($"{person.Id}. {person.FirstName} {person.LastName}" + " (Counselor)"); } // visar att person är counselor om så är fallet

                else
                {
                    Console.WriteLine($"{person.Id}. {person.FirstName} {person.LastName} ");
                }
            }

            int personId = int.Parse(Console.ReadLine());
            var selectedPerson = persons.FirstOrDefault(p => p.Id == personId);

            if (selectedPerson != null)
            {
                var cabinAssignmentManager = new CabinManager(context);
                AssignToCabin(selectedPerson);
                
            }
            else
            {
                Console.WriteLine("Invalid person Id. Assignment failed.");
            }
        }

        public void AssignToCabin(Person person)
        {
            if (person is Camper camper)
            {
                Console.WriteLine("Available Cabins:");
                DisplayAvailableCabins();
                Console.Write("Enter the Cabin ID where the Camper should be assigned: ");

                if (int.TryParse(Console.ReadLine(), out int cabinId))
                {
                    AssignCamperToCabin(camper, cabinId);
                }
                else
                {
                    Console.WriteLine("Invalid input. Assignment fasiled.");
                }
            }
            else if (person is Counselor counselor)
            {
                Console.WriteLine("Available Cabins:");
                DisplayAvailableCabins();
                Console.Write("Enter the Cabin ID where the Counselor should be assigned: ");

                if (int.TryParse(Console.ReadLine(), out int cabinId))
                {
                    AssignCounselorToCabin(counselor, cabinId);
                }
                else
                {
                    Console.WriteLine("Invalid input. Assignment failed.");
                }
            }
        }

        private void AssignCamperToCabin(Camper camper, int cabinId)
        {
            try
            {
                var cabin = context.Cabins.Include(c => c.Campers).FirstOrDefault(c => c.CabinId == cabinId);

                if (cabin != null && cabin.Campers.Count < cabin.MaxCapacity)
                {
                    var counselorInCabin = context.Cabins
                        .Include(c => c.Counselor)
                        .FirstOrDefault(c => c.CabinId == cabinId)?.Counselor;

                    if (counselorInCabin != null)
                    {
                        cabin.Campers.Add(camper);
                        context.SaveChanges();
                        Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} assigned to Cabin {cabin.CabinId}.");
                    }
                    else
                    {
                        Console.WriteLine("A counselor is required in the cabin before assigning a camper.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cabin selection or no availability for camper assignment.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void AssignCounselorToCabin(Counselor counselor, int cabinId)
        {
            try
            {
                var cabin = context.Cabins.Include(c => c.Counselor).FirstOrDefault(c => c.CabinId == cabinId);

                if (cabin != null)
                {
                    // Kontrollerar så att counselor får plats att dirigera stugan
                    var existingCounselorForCabin = context.Cabins.FirstOrDefault(c => c.Counselor != null && c.Counselor.Id == counselor.Id);

                    if (existingCounselorForCabin == null)
                    {
                        if (cabin.Counselor != null)
                        {
                            Console.WriteLine($"Cabin {cabin.CabinId} already has a counselor assigned:");
                            Console.WriteLine($"Existing Counselor: {cabin.Counselor.FirstName} {cabin.Counselor.LastName}");
                            Console.Write("Do you want to replace the existing counselor with the new one? (Yes/No): ");

                            if (Console.ReadLine() == "Yes")
                            {
                                cabin.Counselor = counselor;
                                context.SaveChanges();
                                Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} replaced the existing counselor in Cabin {cabin.CabinId}.");
                            }
                            else
                            {
                                Console.WriteLine($"Assignment cancelled. Existing Counselor {cabin.Counselor.FirstName} {cabin.Counselor.LastName} remain in Cabin {cabin.CabinId}.");
                            }
                        }
                        else
                        {
                            cabin.Counselor = counselor;
                            context.SaveChanges();
                            Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} assigned to Cabin {cabin.CabinId}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} already assigned to another cabin.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cabin selection.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void DisplayAvailableCabins()
        {
            var availableCabins = context.Cabins.Where(c => c.Counselor == null || c.Campers.Count < c.MaxCapacity).ToList();

            foreach (var cabin in availableCabins)
            {
                Console.WriteLine($"Cabin ID: {cabin.CabinId}, Name: {cabin.Name}");
            }
        }
    }
}


