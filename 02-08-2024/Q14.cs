using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10
{
    internal class Program
    {
        static int PrintNthTermInFibonacci(int N)
        {

            int term1 = 0;
            int term2 = 1;
            int nextTerm = 0;
            int i = 1;
            while (i <= N)
            {
                if (i == 1)
                {
                    term1 = 0;
                }
                else if (i == 2)
                {
                    term2 = 1;
                }
                else
                {
                    nextTerm = term1 + term2;
                    //Console.Write(nextTerm + " ");
                    term1 = term2;
                    term2 = nextTerm;
                }
                i++;
            }

            return nextTerm;

        }

        static void TestPrintNthTermInFibonacci()
        {
            Console.WriteLine("Enter the number");
            int N = int.Parse(Console.ReadLine());
            int nthTerm = PrintNthTermInFibonacci(N);
            Console.WriteLine(nthTerm);
        }

        static void Main(string[] args)
        {
            TestPrintNthTermInFibonacci();
        }
    }
}
