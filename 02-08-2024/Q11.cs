using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11
{
    internal class Program
    {
        static void PrintFibonacci(int N)
        {
            int term1 = 0;
            int term2 = 1;
            int nextTerm;
            int i = 1;
            while(i <= N)
            {
                if (i == 1)
                {
                    Console.Write(0 + " ");
                }
                else if (i == 2)
                {
                    Console.Write(1 + " ");
                }
                else
                {
                    nextTerm = term1 + term2;
                    Console.Write(nextTerm + " ");
                    term1 = term2;
                    term2 = nextTerm;
                }
                i++;
            }

        }

        static void TestPrintFibonacci()
        {
            Console.WriteLine("Enter the number of terms");
            int N = int.Parse(Console.ReadLine());
            PrintFibonacci(N);
        }

        static void Main(string[] args)
        {
            TestPrintFibonacci();
        }
    }
}
