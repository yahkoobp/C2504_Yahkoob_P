using System;

public class EmployeeSalaries
{
    private double[,] SalaryMatrix;
    public EmployeeSalaries(int rows , int cols)
    {
        SalaryMatrix = new double[rows , cols];
    }

    public double this[int rowIndex , int colIndex]
    {
        get
        {
            return SalaryMatrix[rowIndex , colIndex];
        }
        set
        {
            SalaryMatrix[rowIndex , colIndex] = value;
        }
    }
}
internal class Programs
{


    static void Main(string[] args)
    {
        Console.Write("Number of rows in Salary matrix:");
        int R = int.Parse(Console.ReadLine());
        Console.Write("Number of columns in Salary matrix:");
        int C = int.Parse(Console.ReadLine());
        EmployeeSalaries employeeSalaries = new EmployeeSalaries(R , C);
        Console.WriteLine($"Enter salaries one by one.");
        for (int I = 0; I < R; I++)
        {
            for (int J = 0; J < C; J++)
            {
            Console.Write($"Salary");
            employeeSalaries[I , J] = double.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine($"Salaries:");
        for (int I = 0; I < R; I++)
        {
            for (int J = 0; J < C; J++)
            {

                Console.WriteLine($"{employeeSalaries[I, J]}");
            }
            Console.WriteLine();
        }
        
    }
}
