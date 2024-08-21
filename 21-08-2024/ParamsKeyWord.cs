using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsKeyword
{
    internal class Program
    {
        static int Add(int x , int y, params int[] nums) // for minimum two parameters
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum + x + y;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Add(1,2,3,4,5,6,7,8,9,10));
        }
    }
}
