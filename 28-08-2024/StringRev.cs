using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            string rev = "";
            for (int i = str.Length - 1; i >= 0 ; i--)
            {
                rev += str[i];
            }
            Console.WriteLine($"Reversed string is  {rev}");
        }
    }
}
