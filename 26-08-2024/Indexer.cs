using System;

public class EmployeeSalaries
{
    private double[] salaries;
    public EmployeeSalaries(int size)
    {
        salaries = new double[size];
    }

    public double this[int index]
    {
        get
        {
            return salaries[index];
        }
        set
        {
            salaries[index] = value;
        }
    }
}
internal class Programs
{


    static void Main(string[] args)
    {
        Console.Write("Number of Salaries:");
        int N = int.Parse(Console.ReadLine());
        EmployeeSalaries employeeSalaries = new EmployeeSalaries(N);
        Console.WriteLine($"Enter {N} salaries one by one.");
        for (int I = 0; I < N; I++)
        {
            Console.Write($"Salary {I + 1}:");
            employeeSalaries[I] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine($"Salaries:");
        for (int I = 0; I < N; I++)
        {
            Console.Write($"{employeeSalaries[I]} ");
        }
        Console.WriteLine();
    }
}
