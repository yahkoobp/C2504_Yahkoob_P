using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace FileDemo
{
    internal class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class PersonManager
        {
            public List<Person> Persons { get; set; } = new List<Person>();

            public void Add(Person person)
            {
                Persons.Add(person);
                // Serialization
                string jsonString = JsonSerializer.Serialize(Persons);
                Console.WriteLine(jsonString); //DEBUG
                using (FileStream fs = new FileStream("persons.json", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(jsonString);
                    }
                }
            }
            public void ReadAll()
            {
                string jsonString = "";
                if (!File.Exists("persons.json")) { return; }
                using (FileStream fs = new FileStream("persons.json", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        jsonString = sr.ReadToEnd();
                    }
                }
                Persons = JsonSerializer.Deserialize<List<Person>>(jsonString);
                Persons.ForEach(person => Console.WriteLine($"[{person.Name},{person.Age}] "));
            }
        }
        static void Main(string[] args)
        {
            PersonManager manager = new PersonManager();
            manager.ReadAll();
            manager.Add(new Person { Name = "Dhoni", Age = 42 });
            manager.Add(new Person { Name = "Dravid", Age = 50 });
            manager.Add(new Person { Name = "Kohli", Age = 35 });
            manager.Add(new Person { Name = "Surya", Age = 30 });
            manager.ReadAll();
        }
    }
}
