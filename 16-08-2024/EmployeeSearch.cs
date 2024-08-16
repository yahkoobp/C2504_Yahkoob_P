using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} {Environment.NewLine}" +
                $"Email: {Email} {Environment.NewLine}" +
                $"Age: {Age}";
        }
    }

    class EmployeeManager
    {
        private Employee[] employees = new Employee[10];
        private int _count;

        public void Add()
        {
            var emp = new Employee();
            Console.Write("Name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Email: ");
            emp.Email = Console.ReadLine();
            Console.Write("Age: ");
            emp.Age = int.Parse(Console.ReadLine());
            employees[_count] = emp;
            _count++;
        }

        public void Search()
        {
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            for (int i = 0; i < _count; i++)
            {
                var e = employees[i];
                if (e.Email == email)
                {
                    Console.WriteLine(e);
                    break;
                }
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            EmployeeManager manager = new EmployeeManager();

            while (true)
            {
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Search employee");
                Console.Write("Please enter your option: ");
                var option = Console.ReadLine();
                

                switch (option)
                {
                    case "1":
                        manager.Add();
                        break;
                    case "2":
                        manager.Search();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

    }
}
