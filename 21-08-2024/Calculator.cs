using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    public class Calculator
    {
        // Method to add two integers
        public int Add(int a, int b)
        {
            Console.WriteLine("Add(int a, int b)");
            return a + b;
        }

        // Overloaded method to add three integers
        public int Add(int a, int b, int c)
        {
            Console.WriteLine("Add(int a, int b , int c)");
            return a + b + c;
        }

        // Overloaded method to add two double values
        public double Add(double a, double b)
        {
            Console.WriteLine("Add(double a, double b)");
            return a + b;
        }

        // Overloaded method to concatenate two strings
        public string Add(string a, string b)
        {
            Console.WriteLine("Add(string a, string b)");

            return a + b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            int sum1 = calculator.Add(5, 10);           // Calls Add(int, int)
            int sum2 = calculator.Add(5, 10, 15);       // Calls Add(int, int, int)
            double sum3 = calculator.Add(5.5, 10.5);    // Calls Add(double, double)
            double sum4 = calculator.Add(5, 10.5);
            string concatenated = calculator.Add("Hello, ", "World!");  // Calls Add(string, string)

            Console.WriteLine(sum1);       // Output: 15
            Console.WriteLine(sum2);       // Output: 30
            Console.WriteLine(sum3);    // Output: 16.0
            Console.WriteLine(sum4);
            Console.WriteLine(concatenated);  // Output: Hello, World!

        }
    }
}
