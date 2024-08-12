using System;


namespace PatientAgesTillLessThanZero
{
    internal class Program
    {
        class Minnu
        {
            static void ReadPatientAgeTillBelowZero()
            {
                int count = 0;
                int countOdd = 0;
                int sum = 0;
                int avg = 0;
                int primeSum = 0;
                int teenagerSum = 0;
                int min = int.MaxValue;
                int oddSum = 0;
                bool isMinPrime = false;
                int maxAdult = int.MinValue, secondMaxAdult = int.MinValue;
                int[] patientsAgeArr = new int[10];

                //
                 i = 0;
                do
                {
                    patientsAgeArr[i] = int.Parse(Console.ReadLine());

                    if (patientsAgeArr[i] < 0) //to stop input cond
                    {
                        break;
                    }
                    if (patientsAgeArr[i] == 0) //validation
                    {
                        Console.WriteLine("invalid age");
                        continue;
                    }

                    count++;
                    if (IsOdd(patientsAgeArr[i])) // check for odd number ages
                    {
                        countOdd++;
                        oddSum += patientsAgeArr[i];
                    }
                    if (IsAdult(patientsAgeArr[i])) // check for adult age
                    {
                        if (patientsAgeArr[i] > maxAdult)// check for max adult age
                        {
                            if (maxAdult != int.MaxValue)
                            {
                                secondMaxAdult = maxAdult;
                            }
                            maxAdult = patientsAgeArr[i];
                        }
                        else if (patientsAgeArr[i] > secondMaxAdult && patientsAgeArr[i] != maxAdult)
                        {
                            secondMaxAdult = patientsAgeArr[i];
                        }
                    }
                    sum = sum + patientsAgeArr[i];
                    if (IsPrime(patientsAgeArr[i])) // check for prime ages
                    {
                        primeSum += patientsAgeArr[i];
                    }

                    if (IsTeenager(patientsAgeArr[i])) // check for teenager
                    {
                        teenagerSum += patientsAgeArr[i];
                    }

                    if (patientsAgeArr[i] < min)// check for min age
                    {
                        min = patientsAgeArr[i];
                    }
                    i++;
                } while (!(patientsAgeArr[i] < 0));


                isMinPrime = IsPrime(min);


                avg = sum / count; // to find average
                Console.WriteLine($"Average Age: {avg}");
                Console.WriteLine($"Prime Ages sum: {primeSum}"); //Anjana NK
                Console.WriteLine($"Teenagers' Age Sum: {teenagerSum}");
                Console.WriteLine($"Min Age#: {min}");
                Console.WriteLine($"Odd Age Sum#: {oddSum}");
                if (secondMaxAdult == int.MaxValue)
                {
                    Console.WriteLine("Second Max Adult Age does not exist");
                }
                else
                {
                    Console.WriteLine($"Second Max Adult Age#: {secondMaxAdult}");
                }

                if (isMinPrime) // check if Minimum age is prime
                {
                    Console.WriteLine("Minimum age is also prime");
                }
                else
                {
                    Console.WriteLine("Minimum age is not prime");
                }
            }

            static bool IsPrime(int age)
            {
                bool isPrime = true;
                int sqrtAge = (int)Math.Sqrt((double)age);
                for (int i = 2; i <= sqrtAge; i++)
                {
                    if (age % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                return isPrime;
            }
            static bool IsTeenager(int age)
            {
                return ((age >= 13) && (age <= 19));
            }
            static bool IsAdult(int age)
            {
                return (age > 19);
            }

            static bool IsOdd(int age)
            {
                return age % 2 != 0;
            }


            static void TestReadPatientAgeTillBelowZero()
            {
                ReadPatientAgeTillBelowZero();
            }

            static void Main(string[] args)
            {
                Console.WriteLine("-----TestReadPatientAgeTillBelowZero-----");
                TestReadPatientAgeTillBelowZero();
                Console.WriteLine("-----End TestReadPatientAgeTillBelowZero-----");

            }
        }
    }
}
