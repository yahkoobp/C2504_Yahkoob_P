/*
 1.Implement an Abstract Class with Method Overriding
   - Task: Create an abstract class `Employee` with an abstract method `CalculateSalary()`. Derive two classes `FullTimeEmployee` and `PartTimeEmployee` from `Employee`.
   - Requirements:
     - `FullTimeEmployee` should have properties `BaseSalary` and `BonusPercentage`. Implement the `CalculateSalary()` method to return the total salary, including bonus.
     - `PartTimeEmployee` should have properties `HourlyRate` and `HoursWorked`. Implement the `CalculateSalary()` method to return the total earnings based on hours worked.
   - Example:
     ```csharp
     Employee fullTime = new FullTimeEmployee(50000, 0.1); 
     Console.WriteLine(fullTime.CalculateSalary());  // Output: 55000

     Employee partTime = new PartTimeEmployee(20, 80); 
     Console.WriteLine(partTime.CalculateSalary());  // Output: 1600
*/


using System;

abstract class Employee
{
    public abstract decimal CalculateSalary();
}

class FullTimeEmployee : Employee
{
    public decimal BaseSalary { get; set; }
    public decimal BonusPercentage { get; set; }

    public FullTimeEmployee(decimal baseSalary, decimal bonusPercentage)
    {
        BaseSalary = baseSalary;
        BonusPercentage = bonusPercentage;
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + (BaseSalary * BonusPercentage);
    }
}

class PartTimeEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public PartTimeEmployee(decimal hourlyRate, int hoursWorked)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}

class Program
{
    static void Main()
    {
        Employee fullTime = new FullTimeEmployee(50000, 0.1m);
        Console.WriteLine(fullTime.CalculateSalary());  // Output: 55000

        Employee partTime = new PartTimeEmployee(20, 80);
        Console.WriteLine(partTime.CalculateSalary());  // Output: 1600
    }
}
