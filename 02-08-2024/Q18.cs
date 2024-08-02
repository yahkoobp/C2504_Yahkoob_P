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
            int i = 1;
            do
            {
                if(N == 0)
                {
                    break;
                }
                int space = N - i;
                int num = N;
                int j = 1;
                while (j <= N)
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
                    j++;
                }
                i++;
                Console.WriteLine();
            } while (i <= N);
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
