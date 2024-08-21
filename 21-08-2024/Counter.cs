using System;

public static class MathUtilities
{
    // A static field
    public static double Pi = 3.14159;

    // A static method
    public static double Square(double number)
    {
        return number * number;
    }

    // A static property
    public static int Counter { get; private set; }

    // A static constructor
    static MathUtilities()
    {
        Counter = 0;
    }

    // Another static method
    public static void IncrementCounter()
    {
        Counter++;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Accessing static members without creating an instance of the class
        Console.WriteLine(MathUtilities.Pi);

        double result = MathUtilities.Square(5);
        Console.WriteLine(result); // Output: 25

        MathUtilities.IncrementCounter();
        Console.WriteLine(MathUtilities.Counter); // Output: 1
    }
}
