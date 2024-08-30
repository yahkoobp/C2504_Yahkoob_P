using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    internal class Program
    {
        static bool isEven(int num)
        {
            return num % 2 == 0;
        }

        static bool isOdd(int num)
        {
            return num % 2 != 0;
        }

        static void Check(List<int> nums ,  Predicate<int> check)
        {
            foreach(var num in nums)
            {
                if (check(num))
                {
                    Console.WriteLine(num);
                }

            }
        }


        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            Console.WriteLine("Enter the number of elements");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements of list");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Enter element {i + 1}");
                int element = int.Parse(Console.ReadLine());
                nums.Add(element);
            }
            Predicate<int> even = isEven;
            Predicate<int> odd = isOdd;

            Check(nums, even);

        }
    }
}
