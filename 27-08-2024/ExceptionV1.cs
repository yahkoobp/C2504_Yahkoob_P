using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionV1
{
    public class Service
    {
        public static long FindSumOfThirdAndFourth(long[] arr)
        {
            if (arr.Length < 4)
            {
                Console.WriteLine("3rd or 4th element is not there");
                return -1;
            }
            return arr[2] + arr[3];
        }
    }
    internal class Programs
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Programs));

        static void Main(string[] args)
        {
            //long[] nums = { 10, 20, 30, 40, 50, 60, 70, 80, 90 }; //No Err
            long[] nums = { 10, 20, 30 }; //Err
            long sum = 0;

            try
            {
                if (nums.Length >= 4)
                {
                    sum = Service.FindSumOfThirdAndFourth(nums);
                }
                //sum = Service.FindSumOfThirdAndFourth(nums);
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error(ex.Message);
            }

            log.Info(sum);//Log.Info

        }
    }
}
