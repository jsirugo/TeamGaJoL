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
            var cabins = context.Cabins.Include(c => c.Campers).ToList();

            Console.WriteLine("\nCabin Occupants:");
            foreach (var cabin in cabins)
            {
                Console.WriteLine($"Cabin ID: {cabin.CabinId}, Name: {cabin.Name}");

                if (cabin.Campers.Any()) // any= booleanskt uttryck som kollar om det finns något i den. om ja, true, om nej, falskt
                {
                    Console.WriteLine("Occupants:");
                    foreach (var camper in cabin.Campers)
                    {
                        Console.WriteLine($" - CamperId: {camper.Id}. {camper.FirstName} {camper.LastName}");
                    }
                }
                else
                {
                    Console.WriteLine("No occupants!");
                }

                Console.WriteLine();
            }
        }

        public void PersonSelecter()
        {


            Console.WriteLine("\n Who do you want to assign to a cabin?");
            var persons = context.Persons.ToList();

            foreach (var person in persons)
            {
                if (person is Councelor councelor) { Console.WriteLine($"{person.Id}. {person.FirstName} {person.LastName}" + " (Councelor)"); } // visar att person är councelor om så är fallet

                else
                {
                    Console.WriteLine($"{person.Id}. {person.FirstName} {person.LastName}");
                }
            }

            int personId = int.Parse(Console.ReadLine());
            var selectedPerson = persons.FirstOrDefault(p => p.Id == personId);

            if (selectedPerson != null)
            {
                var cabinAssignmentManager = new CabinManager(context);
                AssignToCabin(selectedPerson);
                Console.WriteLine($"Successfully assigned {selectedPerson.FirstName} {selectedPerson.LastName} to a cabin.");
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
                AssignCamperToCabin(camper);
            }
            else if (person is Councelor councelor)
            {
                AssignCouncelorToCabin(councelor);
            }
           
        }



        private void AssignCamperToCabin(Camper camper)
        {
            try
            {

                var cabinWithCouncelor = context.Cabins
            .Include(c => c.Campers) 
            .FirstOrDefault(c => c.Campers.Count < 4);

                if (cabinWithCouncelor != null)
                {
                
                    cabinWithCouncelor.Campers.Add(camper);

                    context.SaveChanges();
                    Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} assigned to Cabin {cabinWithCouncelor.CabinId}.");
                }
                else
                {
                    Console.WriteLine("No cabin available for camper assignment. A cabin with a councelor is needed.");
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        private void AssignCouncelorToCabin(Councelor councelor)
        {
            try
            {

                var assignedCabin = context.Cabins.FirstOrDefault(c => c.Councelor != null && c.Councelor.Id == councelor.Id); // ser så inte samma councelor blir assignad två gånger till samma cabin

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
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }
}


