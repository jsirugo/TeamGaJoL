using CampSleepway_TeamGaJoL;
using Microsoft.EntityFrameworkCore;

using var context = new CampSleepawayContext();
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Camperlist.csv");
var persons = ReadCSV("Camperlist.csv");
Console.WriteLine($"{persons.Count} rader hittade i CSV filen");
//Kör enbart ifall personer inte är tillagda i eran list
//foreach (var person in persons)
//{
//    context.Persons.Add(person);
//}
//context.SaveChanges();
//Console.WriteLine("Personer tillagda i listan");
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

        if (values.Length == 5)
        {
            var firstName = values[0];
            var lastName = values[1];
            var phoneNumber = values[2];
            var sex = values[3];
            var age = int.Parse(values[4]);

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
    return persons;
}