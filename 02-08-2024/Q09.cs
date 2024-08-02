using System;

class Q08
{

    static void PrintNumTriangleMirroredRightAngle(int N)
    {
        int I = 1;

        do
        {
            int j = 1;
            if (N == 0)
            {
                break;
            }
            while (j <= N - I)
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
        } while (I <= N);
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
