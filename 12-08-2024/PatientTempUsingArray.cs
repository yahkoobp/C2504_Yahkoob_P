using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsTempTillZero
{
    internal class Program
    {
        static void ReadPatientTemperatureTillZero()
        {
            int count = 0;
            int countOdd = 0;
            int sum = 0;
            int avg = 0;
            int primeSum = 0;
            int min3DigitsTemperaturerSum = 0;
            int min = int.MaxValue;
            int oddSum = 0;
            bool isMinPrime = false;
            int maxOdd = int.MinValue, secondMaxOdd = int.MinValue;


            //
            int i = 0;
            int[] tempArr = new int[10];
            do
            {
                tempArr[i] = int.Parse(Console.ReadLine());

                if (tempArr[i] == 0) //to stop input cond
                {
                    break;
                }
                if (tempArr[i] < 0) //validation
                {
                    Console.WriteLine("invalid temperature");
                    continue;
                }

                count++;
                if (IsOdd(tempArr[i])) // check for odd number temperatures
                {
                    countOdd++;
                    oddSum += tempArr[i];

                    if (tempArr[i] > maxOdd)// check for max odd temperature
                    {
                        if (maxOdd != int.MaxValue)
                        {
                            secondMaxOdd = maxOdd;
                        }
                        maxOdd = tempArr[i];
                    }
                    else if (tempArr[i] > secondMaxOdd && tempArr[i] != maxOdd)
                    {
                        secondMaxOdd = tempArr[i];
                    }
                }
                sum = sum + tempArr[i];
                if (IsPrime(tempArr[i])) // check for prime temperatures
                {
                    primeSum += tempArr[i];
                }

                if (IsMinThreeDigits(tempArr[i])) // check for teentemperaturer
                {
                    min3DigitsTemperaturerSum += tempArr[i];
                }

                if (tempArr[i] < min)// check for min temperature
                {
                    min = tempArr[i];
                }
            } while (tempArr[i] != 0);


            isMinPrime = IsPrime(min);


            avg = sum / count; // to find avertemperature
            Console.WriteLine($"Average Temperature: {avg}");
            Console.WriteLine($"Prime Temperatures sum: {primeSum}");
            Console.WriteLine($"min 3 digits Temperature Sum: {min3DigitsTemperaturerSum}");
            Console.WriteLine($"Min Temperature: {min}");
            Console.WriteLine($"Odd Temperature Sum: {oddSum}");
            if (secondMaxOdd == int.MaxValue)
            {
                Console.WriteLine("Second Max Odd Temperature does not exist");
            }
            else
            {
                Console.WriteLine($"Second Max Odd Temperature: {secondMaxOdd}");
            }

            if (isMinPrime) // check if Minimum temperature is prime
            {
                Console.WriteLine("Minimum temperature is also prime");
            }
            else
            {
                Console.WriteLine("Minimum temperature is not prime");
            }
        }

        static bool IsPrime(int temperature)
        {
            bool isPrime = true;
            int sqrtTemperature = (int)Math.Sqrt((double)temperature);
            for (int i = 2; i <= sqrtTemperature; i++)
            {
                if (temperature % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
        static bool IsMinThreeDigits(int temperature)
        {
            return (temperature >= 100);
        }

        static bool IsOdd(int temperature)
        {
            return temperature % 2 != 0;
        }

        static void TestReadPatientTemperatureTillZero()
        {
            ReadPatientTemperatureTillZero();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----TestReadPatientTemperatureTillZero-----");
            TestReadPatientTemperatureTillZero();
            Console.WriteLine("-----End TestReadPatientTemperatureTillZero-----");
            Console.WriteLine("Press any key to contine...");
            Console.ReadKey();
        }

    }
}
