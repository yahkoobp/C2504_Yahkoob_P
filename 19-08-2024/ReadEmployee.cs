using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public abstract class Employee
    {
        public abstract double CalculateSalary();
    }

    public class FullTimeEmployee : Employee
    {
        public double BaseSalary { get; set; }
        public double BonusPercentage { get; set; }

        public FullTimeEmployee()
        {
            BaseSalary = 0;
            BonusPercentage = 0;
        }

        public void Read()
        {
            Console.WriteLine("Please enter the Base salary");
            BaseSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the bonus percentege");
            BonusPercentage = double.Parse(Console.ReadLine());

        }

        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * BonusPercentage);
        }

        public override string ToString()
        {
            return $"the fulltime employee with total salary = {CalculateSalary()}";
        }

    }

    public class PartTimeEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee()
        {
            HourlyRate = 0;
            HoursWorked = 0;
        }

        public void Read()
        {
            Console.WriteLine("Please enter the Hourly rate");
            HourlyRate = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the hourse worked");
            HoursWorked = double.Parse(Console.ReadLine());
        }

        public override double CalculateSalary()
        {
            return HoursWorked * HourlyRate;
        }

        public override string ToString()
        {
            return $"the partime employee with total salary = {CalculateSalary()}";
        }
    }

    enum EmployeeType
    {
        FULLTIME = 1,
        PARTTIME = 2
    }
    internal class Program
    {
        static void Run()
        {
            EmployeeType empType;
            Employee employee;
            Employee minSalariedEmp = null;
            Employee maxSalariedEmp = null;
            string choice;
            double maxSalary = double.MinValue;
            double minSalary = double.MaxValue;
            do
            {

                employee = null;
                Console.WriteLine("1.FULLTIME---->2.PARTTIME");
                empType = (EmployeeType)int.Parse(Console.ReadLine());
                switch (empType)
                {
                    case EmployeeType.FULLTIME:
                        FullTimeEmployee fullEmp = new FullTimeEmployee();
                        employee = fullEmp;
                        fullEmp.Read();
                        break;
                    case EmployeeType.PARTTIME:
                        PartTimeEmployee partEmp = new PartTimeEmployee();
                        employee = partEmp;
                        partEmp.Read();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
                if (employee.CalculateSalary() < minSalary)
                {
                    minSalary = employee.CalculateSalary();
                    minSalariedEmp = employee;
                }

                if (employee.CalculateSalary() > maxSalary)
                {
                    maxSalary = employee.CalculateSalary();
                    maxSalariedEmp = employee;
                }
                Console.WriteLine("Do you want to continue : y/n ?");
                choice = Console.ReadLine();



            } while (choice.ToLower() == "y");

            Console.WriteLine($"The employee with minimum salary is {minSalariedEmp}");
            Console.WriteLine($"The employee with maximum salary is {maxSalariedEmp}");
        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
