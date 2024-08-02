using System;

class Q01
{
    static void PrintSeries10_12_14(int numOfTerms)
    {
        int term = 10;
        for (int I = 1; I <= numOfTerms; I++)
        {
            Console.Write($"{term} ");
            term = term + 2;
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
