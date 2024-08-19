using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeArray
{
    public abstract class Employee
    {
        public abstract double CalculateSalary();
        public bool isGT(Employee other)
        {
            return this.CalculateSalary() > other.CalculateSalary();
        }

        public bool isEQ(Employee other)
        {
            return this.CalculateSalary() == other.CalculateSalary();
        }

        public bool isLT(Employee other)
        {
            return this.CalculateSalary() < other.CalculateSalary();
        }
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
        static void SelectionSort(Employee[] emp)
        {
            int l = emp.Length;
            for(int i = 0; i < l - 1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < l; j++)
                {
                    if (emp[j].isLT(emp[minIndex]))
                    {
                        minIndex = j;
                    }
                }

                Employee temp = emp[minIndex];
                emp[minIndex] = emp[i];
                emp[i] = temp;

            }

        }
        static void Run()
        {
            Employee employee;
            EmployeeType empType;
            Console.WriteLine("Please enter the number of employees");
            int N = int.Parse(Console.ReadLine());
            Employee[] employees = new Employee[N];
            for(int i =0; i < N;  i++)
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
                        employees[i] = employee;
                        break;
                    case EmployeeType.PARTTIME:
                        PartTimeEmployee partEmp = new PartTimeEmployee();
                        employee = partEmp;
                        partEmp.Read();
                        employees[i] = employee;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }

            Console.WriteLine("Before sorting");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{employees[i]}");
            }

            // selection sorting
            Console.WriteLine("After sorting...");
            SelectionSort(employees);
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{employees[i]}");
            }
        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
