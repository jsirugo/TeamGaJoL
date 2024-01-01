﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class AddCSV
    {
        public static void AddCSVData()
        {
            using var context = new CampSleepawayContext();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "People.csv");
            var persons = ReadCSV(filePath);
            Console.WriteLine($"{persons.Count} records found in the CSV file");

            // Körs enbart ifall databasen är tom
            if (!context.Persons.Any())
            {
                foreach (var person in persons)
                {
                    context.Persons.Add(person);
                }
                context.SaveChanges();
                Console.WriteLine("Persons added to the database");
            }
            else
            {
                Console.WriteLine("Persons are already added to the database");
            }
        }

        private static List<Person> ReadCSV(string filePath)
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
