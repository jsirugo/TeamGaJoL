using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class AddPerson
    {
        private readonly CampSleepawayContext contextfile;

        public AddPerson(CampSleepawayContext dbContext)
        {
            contextfile = dbContext;
        }

        public void AddPersonToDatabase()
        {
            Console.Clear();
            try
            {

            Console.WriteLine("Enter person details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Sex: ");
            string sex = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter a number to be assigned to the different person types: (Camper, Counselor, NextOfKin): ");
                Console.WriteLine("\nPress  '1' to be assigned to 'Camper' \nPress '2' to be assigned to 'Counselor'\nPress '3' to be assigned to NextOfKin"   );
            int personType = int.Parse(Console.ReadLine());

                if (personType == 1)
            {
                AddCamper(firstName, lastName, phoneNumber, sex, age);
            }
            else if (personType == 2)
            {
                AddCounselor(firstName, lastName, phoneNumber, sex, age);
            }
            else if (personType == 3)
            {
                AddNextOfKin(firstName, lastName, phoneNumber, sex, age);
            }
            else
            {
                Console.WriteLine("Invalid person type.");
            }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        private void AddCamper(string firstName, string lastName, string phoneNumber, string sex, int age)
        {
            try
            {

            Console.Write("Camper Start Date: (yyyy-MM-dd) ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Camper End Date (press enter if none): (yyyy-MM-dd) ");
            DateTime? endDate = DateTime.TryParse(Console.ReadLine(), out var result) ? result : (DateTime?)null; 

          
            var camper = new Camper
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Sex = sex,
                Age = age,
                StartDate = startDate,
                EndDate = endDate
            };

            contextfile.Campers.Add(camper);
            contextfile.SaveChanges();
            Console.WriteLine("Camper successfully added to database!");
            Console.ReadKey();
            Console.Clear();
            }

            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        private void AddCounselor(string firstName, string lastName, string phoneNumber, string sex, int age)
        {
            
            Console.Write("Counselor Start Date:(yyyy-MM-dd) ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Counselor End Date (yyyy-MM-dd) (press enter if none): ");
            DateTime? endDate = DateTime.TryParse(Console.ReadLine(), out var result) ? result : (DateTime?)null;

            
            var counselor = new Counselor
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Sex = sex,
                Age = age,
                StartDate = startDate,
                EndDate = endDate
            };

            contextfile.Counselors.Add(counselor);
            contextfile.SaveChanges();
            Console.WriteLine("Counselor successfully added to database!");
            Console.ReadKey();
            Console.Clear();
        }

        private void AddNextOfKin(string firstName, string lastName, string phoneNumber, string sex, int age)
        {
            try
            {


            Console.WriteLine("List of Campers:");
            var campers = contextfile.Campers.ToList();
                // visar lista med campers att välja på
            foreach (var camper in campers)
            {
                Console.WriteLine($"{camper.Id}. {camper.FirstName} {camper.LastName}");
            }


            Console.Write("Enter the Camper Id to associate with NextOfKin: ");
            int camperId = int.Parse(Console.ReadLine());


            var selectedCamper = campers.FirstOrDefault(c => c.Id == camperId);
            if (selectedCamper == null ||camperId > campers.Max(c => c.Id) || camperId < 0) 
            {
                Console.WriteLine("Invalid Camper Id. NextOfKin needs to be connected to a camper. Returning.");
                return;
            }


            var nextOfKin = new NextOfKin
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Sex = sex,
                Age = age,
                CamperId = camperId
            };
             
                
            contextfile.NextOfKins.Add(nextOfKin);
            contextfile.SaveChanges();
            Console.WriteLine("NextOfKin added successfully!");
            Console.ReadKey();
            Console.Clear();
            }
            catch(Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }
}
