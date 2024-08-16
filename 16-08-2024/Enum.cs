using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    internal class Program
    {
        enum Convertions
        {
            Upper,
            Lower,
            Trim
        }
        static string Convert(string input , Convertions op)
        {
            string result = "";
            switch (op)
            {
                case Convertions.Upper:
                    result = input.ToUpper();
                    break;

                case Convertions.Lower:
                    result = input.ToLower();
                    break;

                case Convertions.Trim:
                    result = input.Trim();
                    break;


            }

            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine();
            Console.WriteLine($"The resultant string is {Convert(input ,Convertions.Upper)}");
        }
    }
}
