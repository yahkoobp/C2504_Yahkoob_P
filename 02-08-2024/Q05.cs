using System;

class Q05
{
 
    static int GetNthTerm_21_22_24_27(int N)
    {
        int term = 21;
        int difference = 1;
        int I = 1;
        while (I <= N)
        {
            if (I == N)
            {
                break;
            }
            //
            term = term + difference;
            difference = difference + 1;

            I++;
        }
        return term;
    }

    static void TestGetNthTerm_21_22_24_27()
    {
        Console.Write("Enter number of terms:");
        int N = int.Parse(Console.ReadLine());
        int nthTerm = GetNthTerm_21_22_24_27(N);
        Console.WriteLine($"Nth term is {nthTerm}");
    }
    static void Main(string[] args) 
    {
        Console.WriteLine("-----TestGetNthTerm_21_22_24_27-----");
        TestGetNthTerm_21_22_24_27();
        Console.WriteLine("-----End TestGetNthTerm_21_22_24_27-----");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}
