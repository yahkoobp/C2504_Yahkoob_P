using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Student.cs
{

    class Student
    {
        public string Name;
        public int Mark1;
        public int Mark2;
        public int Mark3;

        public int TotalMarks()
        {
            return Mark1 + Mark2 + Mark3;
        }

        public int AvgMarks()
        {
            int avg = (Mark1 + Mark2 + Mark3) / 3;
            return avg;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.Name = "Yahkoob";
            s1.Mark1 = 20;
            s1.Mark2 = 40;
            s1.Mark3 = 34;

            var s2 = new Student()
            {
                Name = "John",
                Mark1 = 20,
                Mark2 = 34,
                Mark3 = 24
            };
            

            Console.WriteLine($"total marks for {s1.Name} is {s1.TotalMarks()}");
            Console.WriteLine($"average marks for first student is {s1.AvgMarks()}");

            Console.WriteLine($"total marks for {s2.Name} is {s2.TotalMarks()}");
            Console.WriteLine($"average marks for second student is {s2.AvgMarks()}");


        }
    }
}
