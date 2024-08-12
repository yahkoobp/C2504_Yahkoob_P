/*"Read doctors' salaries (integer) from keyboard till we read -1 
using array / collection."
Find average salary (integer),
prime salaries count(example: Rs.101, prime number salary),
minimum 4 digit salaries count,
maximum salary,
odd salaries sum (example: Rs.5001), and
2nd minimum odd salary.  
Check maximum salary is also prime salary.
Use coding standards and best practices to write pseudo code and c# code.
Plan the task codes to make as reusable functions.*/

using System;

namespace DocSalUsingArray1
{

    internal class Program
    {
        //array to read doctor's salaries till -1 using
        static void ReadDocSalArrTillMinus1()
        {
            int[] salArr = new int[100];
            int count = 0, countOdd = 0, sum = 0, avg = 0, primeCount = 0, minFourDigitsCount = 0, max = int.MinValue, oddSum = 0;
            bool isMaxPrime = false;
            int minOdd = int.MaxValue, secondMinOdd = int.MaxValue;
            int n = salArr.Length;
            int salary = 0, i = 0;
            do
            {
                salArr[i] = int.Parse(Console.ReadLine());

                if (salArr[i] == -1) //to stop input cond
                {
                    break;
                }
                if (salArr[i] < 0) //validation
                {
                    Console.WriteLine("invalid salary");
                    continue;
                }

                count++;
                if (IsOdd(salArr[i])) // check for odd number salaries
                {
                    countOdd++;
                    oddSum += salArr[i];

                    if (salArr[i] < minOdd)// check for minimum salary
                    {
                        if (minOdd != int.MaxValue)
                        {
                            secondMinOdd = minOdd;
                        }
                        minOdd = salArr[i];
                    }
                    else if (salArr[i] < secondMinOdd && salArr[i] != minOdd)
                    {
                        secondMinOdd = salArr[i];
                    }
                }
                sum = sum + salArr[i];
                if (IsPrime(salArr[i])) // check for prime salaries
                {
                    primeCount++;
                }

                if (IsMinimumFourDigits(salArr[i])) // check for 4 digits salaries
                {
                    minFourDigitsCount++;
                }

                if (salArr[i] > max)// check for maximum salary
                {
                    max = salArr[i];
                }
                i++;
            } while (salArr[i] != -1);

            isMaxPrime = IsPrime(max);


            avg = sum / count; // to find average
            Console.WriteLine($"Average Salary: {avg}");
            Console.WriteLine($"Prime Salaries#: {primeCount}");
            Console.WriteLine($"Min Four Digits Salaries#: {minFourDigitsCount}");
            Console.WriteLine($"Max Salary#: {max}");
            Console.WriteLine($"Odd Salaries Sum#: {oddSum}");
            Console.WriteLine($"Min Odd Salary#: {minOdd}");
            if (secondMinOdd == int.MaxValue)
            {
                Console.WriteLine("Second Min Odd Salary does not exist");
            }
            else
            {
                Console.WriteLine($"Second Min Odd Salary#: {secondMinOdd}");
            }

            if (isMaxPrime) // check if maximum salary is prime
            {
                Console.WriteLine("Maximum salary is also prime ");
            }
            else
            {
                Console.WriteLine("Maximum salary is not prime ");
            }
        }

        static bool IsPrime(int salary)
        {
            bool isPrime = true;
            int sqrtSal = (int)Math.Sqrt((double)salary);
            for (int i = 2; i <= sqrtSal; i++)
            {
                if (salary % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
        static bool IsMinimumFourDigits(int salary)
        {
            return salary >= 1000;
        }
        static bool IsOdd(int salary)
        {
            return salary % 2 != 0;
        }
        static void TestReadDoctorSalaryTillMinus1()
        {
            ReadDocSalArrTillMinus1();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----TestReadDoctorSalaryTillMinus1-----");
            TestReadDoctorSalaryTillMinus1();
            Console.WriteLine("-----End TestReadDoctorSalaryTillMinus1-----");
        }
    }
}
