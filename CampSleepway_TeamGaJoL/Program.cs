using Azure;
using CampSleepway_TeamGaJoL;
using Microsoft.EntityFrameworkCore;
class Program
{
    static void Main()
    {
        bool running = true;
        while(running)
        {
        int option = MainMenu.ShowMenu("Welcome to Camp Sleepaway! What do you want to do?", new[]
        {
            "Add person to database", // Potentiellt lägga in så man kan ange csv fil att läsas in utöver att mata in manuellt
            "Add cabin",
            "Assign a camper to a cabin",
            "Remove a camper from the camp",
            "Search for campers in Camp Sleepaway",
            "Show a list of all campers sorted on cabins",
            "Add people from external list",
            "Exit" 
           
        });

        if (option == 0)
        {
                Console.Clear();
                CampSleepawayContext dbContext = new CampSleepawayContext(); 

            AddPerson addPerson = new AddPerson(dbContext);

            addPerson.AddPersonToDatabase();
        }

        if (option == 1)
        {
                Console.Clear();
                CampSleepawayContext dbContext = new CampSleepawayContext();
            AddCabin addCabin = new AddCabin(dbContext);

            addCabin.AddCabinToDatabase();
        }

        if (option == 2)
        {
                Console.Clear();
                CampSleepawayContext dbContext = new CampSleepawayContext();
            CabinManager assignperson = new CabinManager(dbContext);
                var cabinManager = new CabinManager(dbContext);
                cabinManager.DisplayCabinOccupants();
                assignperson.PersonSelecter();
                
             
         
            Console.ReadKey();
            Console.Clear();
        }
        if(option == 5)
            {
                Console.Clear();
                CampSleepawayContext dbContext = new CampSleepawayContext();
                CabinManager cabinsorter = new CabinManager(dbContext);
                cabinsorter.DisplayCabinOccupants();
            }
          
        if (option == 6) 
        {
            Console.Clear();

            AddCSV.AddCSVData();
        }
        if (option == 7)
        {
            running = false;
        }


        }
        
    }
}
