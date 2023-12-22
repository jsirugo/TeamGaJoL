using Azure;
using CampSleepway_TeamGaJoL;
using Microsoft.EntityFrameworkCore;
class Program
{
    static void Main()
    {

        using var context = new CampSleepawayContext();
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "People.csv");
        var persons = ReadCSV("People.csv");
        Console.WriteLine($"{persons.Count} rader hittade i CSV filen");
        //Kör enbart ifall personer inte är tillagda i eran list
        //foreach (var person in persons)
        //{
        //    context.Persons.Add(person);
        //}
        //context.SaveChanges();
        //Console.WriteLine("Personer tillagda i listan");

        context.AddRange(persons);
        context.SaveChanges();
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
