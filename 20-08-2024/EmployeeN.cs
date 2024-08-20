using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeN
{
    public abstract class Employee
    {
        public abstract double CalculateSalary();
        public abstract void Read();
    }

    public class FullTimeEmployee : Employee
    {
        public double BaseSalary {  get; set; }
        public double BonusPercentage {  get; set; }

        public FullTimeEmployee()
        {
            BaseSalary = 0;
            BonusPercentage = 0;
        }

        public override void Read()
        {
            Console.WriteLine("Enter base salary");
            BaseSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter bonus percentage");
            BonusPercentage = double.Parse(Console.ReadLine());
        }

        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * BonusPercentage);
        }

        public override string ToString()
        {
            return $"Employee with base salary{BaseSalary} and bonus percentage {BonusPercentage} and total slary {CalculateSalary()}";
        }

    }

    public class PartTimeEmployee : Employee
    {
        public double HourlyRate {  get; set; }
        public double HoursWorked {  get; set; }

        public PartTimeEmployee()
        {
            HourlyRate = 0;
            HoursWorked = 0;
        }

        public override void Read()
        {
            Console.WriteLine("Enter the Hourly rate ");
            HourlyRate = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the hourse worked");
            HoursWorked = double.Parse(Console.ReadLine());
        }

        public override double CalculateSalary()
        {
            return HoursWorked * HourlyRate;
        }

        public override string ToString()
        {
            return $"Employee with hours rate{HourlyRate} and hours worked {HoursWorked} and total salary {CalculateSalary()}";
        }
    }

    enum EmployeeType
    {
        FulltimeEmp = 1,
        PartTimeEmp = 2
    }
    internal class Program
    {

        static void Run()
        {
            EmployeeType empType;
            Employee employee;
            Employee minSalariedEmp = null;
            Employee maxSalariedEmp = null;
            string choice ="";
            double maxSalary = double.MinValue;
            double minSalary = double.MaxValue;

            do
            {
                employee = null;
                Console.WriteLine("1.FullTime ----- 2.PartTime");
                empType = (EmployeeType)int.Parse(Console.ReadLine());
                switch (empType)
                {
                    case EmployeeType.FulltimeEmp:
                        FullTimeEmployee fullEmp = new FullTimeEmployee();
                        employee = fullEmp;
                        fullEmp.Read();
                        break;

                    case EmployeeType.PartTimeEmp:
                        PartTimeEmployee partEmp = new PartTimeEmployee();
                        employee = partEmp;
                        partEmp.Read();
                        break;

                    default:
                        Console.WriteLine("Invalid input , please try again");
                        continue;
                }

                if (employee.CalculateSalary() > maxSalary)
                {
                    maxSalary = employee.CalculateSalary();
                    maxSalariedEmp = employee;
                }

                if (employee.CalculateSalary() < minSalary)
                {
                    minSalary = employee.CalculateSalary();
                    minSalariedEmp = employee;
                }

                Console.WriteLine("Do you want to continue y/n");
                choice = Console.ReadLine();

            } while (choice.ToLower() == "y");

            Console.WriteLine($"The employee with maximum salary is {maxSalariedEmp}");
            Console.WriteLine($"The employee with minimum salary is {minSalariedEmp}");
        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
