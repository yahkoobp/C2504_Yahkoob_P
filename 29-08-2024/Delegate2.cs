using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate2.cs
{
    delegate  double DCalc (double x, double y);
    internal class Program
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            DCalc rCalc = Add;
            Console.WriteLine(rCalc(10 , 20));
        }
    }
}
