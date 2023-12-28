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
            "Exit" 
           
        });

        if (option == 0)
        {
            CampSleepawayContext dbContext = new CampSleepawayContext(); 

            AddPerson addPerson = new AddPerson(dbContext);

            addPerson.AddPersonToDatabase();
        }

        if (option == 1)
        {
            CampSleepawayContext dbContext = new CampSleepawayContext();
            AddCabin addCabin = new AddCabin(dbContext);

            addCabin.AddCabinToDatabase();
        }

        if (option == 2)
        {
            CampSleepawayContext dbContext = new CampSleepawayContext();
            CabinManager assignperson = new CabinManager(dbContext);
            Console.WriteLine("Who do you want to assign to a cabin?");
            var persons = dbContext.Persons.ToList();
            
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
                var cabinAssignmentManager = new CabinManager(dbContext);
                cabinAssignmentManager.AssignToCabin(selectedPerson);
                Console.WriteLine($"Successfully assigned {selectedPerson.FirstName} {selectedPerson.LastName} to a cabin.");
            }
            else
            {
                Console.WriteLine("Invalid person Id. Assignment failed.");
            }
            Console.ReadKey();
            Console.Clear();
        }
          
        if (option == 6) 
        { 
            running = false; 
        }


        }
        using var context = new CampSleepawayContext();
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "People.csv");
       // var persons = ReadCSV("People.csv");
      //  Console.WriteLine($"{persons.Count} rader hittade i CSV filen");
        //Kör enbart ifall personer inte är tillagda i eran list
        //foreach (var person in persons)
        //{
        //    context.Persons.Add(person);
        //}
        //context.SaveChanges();
        //Console.WriteLine("Personer tillagda i listan");

       // context.AddRange(persons);
      //  context.SaveChanges();
        static List<Person> ReadCSV(string filePath)
        {
            var persons = new List<Person>();

            using var reader = new StreamReader(filePath);

            var headerLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                var values = line.Split(',');

                if (values.Length == 8)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var phoneNumber = values[2];
                    var sex = values[3];
                    var age = int.Parse(values[4]);
                    var isCamper = int.Parse(values[5]) == 1;
                    var isCounselor = int.Parse(values[6]) == 1;
                    var isNextOfKin = int.Parse(values[7]) == 1;

                    if (isCamper)
                    {
                        var camper = new Camper
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber,
                            Sex = sex,
                            Age = age,
                            StartDate = DateTime.Now,
                            EndDate = null,
                            NextofKins = new List<NextOfKin>()
                        };

                        persons.Add(camper);
                    }
                    else if (isCounselor)
                    {
                        var counselor = new Councelor
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber,
                            Sex = sex,
                            Age = age,
                            StartDate = DateTime.Now,
                            EndDate = null,
                            NextOfKins = new List<NextOfKin>()
                        };

                        persons.Add(counselor);
                    }
                    else if (isNextOfKin)
                    {
                        var nextOfKin = new NextOfKin
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber,
                            Sex = sex,
                            Age = age
                        };

                        persons.Add(nextOfKin);
                    }
                    else
                    {
                        var person = new Person
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber,
                            Sex = sex,
                            Age = age
                        };

                        persons.Add(person);
                    }
                }
            }
            return persons;
        }
    }
}
