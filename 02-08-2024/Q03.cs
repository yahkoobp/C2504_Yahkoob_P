using System;

class Q03
{
    static void PrintSeries10_12_14(int numOfTerms)
    {
        int term = 10;
        int I = 1;
        do
        {
            if (0 == numOfTerms)
            {
                break;
            }
            Console.Write($"{term} ");
            term = term + 2;

            I++;
        } while (I <= numOfTerms);
    }
   
    static void TestPrintSeries10_12_14()
    {
        Console.Write("Enter number of terms:");
        int numOfTerms = int.Parse(Console.ReadLine());
        Console.Write("Series: ");
        PrintSeries10_12_14(numOfTerms);
        Console.WriteLine();
    }

    static void Main(string[] args) //user: p
    {
        Console.WriteLine("--------------TestPrintSeries10_12_14...--------------");
        TestPrintSeries10_12_14();
        Console.WriteLine("--------------End TestPrintSeries10_12_14...--------------");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}
