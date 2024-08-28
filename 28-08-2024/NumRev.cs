using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int N = int.Parse(Console.ReadLine());
            int rev = 0;
            int temp = N;
            while(temp > 0)
            {
                int rem = temp % 10;
                rev = rev * 10 + rem;
                temp = temp / 10;
            }
            Console.WriteLine($"Reverse is {rev}");
        }
    }
}
