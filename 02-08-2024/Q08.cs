using System;

class Q08
{

    static void PrintNumTriangleMirroredRightAngle(int N)
    {
        int I = 1;
        while(I <= N)
        {
            
            int j = 1;
            while (j <= N-I)
            {
                Console.Write("  ");
                j++;
            }

            int k = 1;
            while (k <= I)
            {
                Console.Write($"{k} ");
                k++;
            }
            I = I + 1;
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
