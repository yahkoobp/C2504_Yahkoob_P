
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    internal class Program
    {
        //0 1 1 2 3 5 8 13.......
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of terms");
            int N = int.Parse(Console.ReadLine());
            int term1 = 0;
            int term2 = 1;
            int term3 = 0;

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{i}\t");
                }
                else if(i == 1)
                {
                    Console.Write($"{i}\t");
                }
                else
                {
    …
[1:07 PM, 8/28/2024] Yahkoob P: using System;
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
