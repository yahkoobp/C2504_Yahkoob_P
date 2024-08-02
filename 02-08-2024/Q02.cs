using System;

class Q02
{
    static void PrintSeries10_12_14(int numOfTerms)
    {
        int term = 10;
        int I = 1;
        while (I <= numOfTerms)
        {
            Console.Write($"{term} ");
            term = term + 2;
            I++;
        }
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
