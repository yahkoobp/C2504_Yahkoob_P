using System;

class Q07
{

    static void PrintNumTriangleMirroredRightAngle(int N)
    {
        for (int I = 1; I <= N; I++)
        {
            for (int J = 1; J <= N - I; J++)
            {
                Console.Write("  "); 
            }
            for (int J = 1; J <= I; J++)
            {
                Console.Write($"{J} ");
            }
            Console.WriteLine();
        }
    }
   
    static void TestPrintNumTriangleMirroredRightAngle()
    {
        Console.Write("Enter number of lines:");
        int N = int.Parse(Console.ReadLine());
        PrintNumTriangleMirroredRightAngle(N);
    }
    static void Main(string[] args) //user: p
    {
        Console.WriteLine("-----TestPrintNumTriangleMirroredRightAngle-----");
        TestPrintNumTriangleMirroredRightAngle();
        Console.WriteLine("-----End TestPrintNumTriangleMirroredRightAngle-----");
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey();
    }
}
