using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.cs
{
    class Calculator
    {
        public int Num1;
        public int Num2;


        public Calculator(int num1, int num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }

        public int Add()
        {
            return this.Num1 + this.Num2;
        }

        public int Sub() => Num1 - this.Num2;
        

        public int Div()
        {
            return this.Num1 / this.Num2;
        }

        public int Mul()
        {
            return this.Num1 * this.Num2;
        }
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter two numbers");
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                Calculator calc = new Calculator(num1, num2);
                Console.WriteLine($"Result after addition is{calc.Add()}");
                Console.WriteLine($"Result after substraction is{calc.Sub()}");
                Console.WriteLine($"Result after multiplication is{calc.Mul()}");
                Console.WriteLine($"Result after division is{calc.Div()}");

            }
        }

 }

