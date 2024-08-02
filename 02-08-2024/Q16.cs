using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q16
{
    internal class Program
    {
        static void PrintTrianglePattern(int N)
        {
            for(int i = 1; i <= N; i++)
            {
                int space = N - i;
                int num = N;
                for (int j = 1; j <= N; j++)
                {
                    if (j <= space)
                    {
                        Console.Write(" " + " ");
                    }
                    else
                    {
                        Console.Write(num + " ");
                        num--;
                    }
                }
                Console.WriteLine();
            }
        }

        static void TestPrintTrianglePattern()
        {
            Console.WriteLine("Enter the number of rows");
            int N = int.Parse(Console.ReadLine());
            PrintTrianglePattern(N);
        }

        static void Main(string[] args)
        {
            TestPrintTrianglePattern();
        }
    }
}
