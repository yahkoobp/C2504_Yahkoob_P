using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpList
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
        public abstract void Read();
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
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

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
        static void InsertionSort(List<Employee> ar)//##
        {
            int N = ar.Count;
            for (int UI = 1; UI < N; UI++) //unsorted list, forward traversal 
            {
                Employee target = ar[UI];//##
                int TI = UI; //init target index
                int SI = UI - 1; //init for sorted list, backward traversal 
                while (SI >= 0 && ar[SI].isGT(target)) //##//'cond for sorted list' and 'is element greater'
                {
                    ar[SI + 1] = ar[SI];//'shift right' parallel to 'SL traversal'
                    TI = SI; //change TI if any greater el in the SL
                    SI--; //decrement for sorted list 
                }
                if (TI != UI)
                {
                    ar[TI] = target;
                }
            }
        }

        static void Run()
        {
            EmployeeType empType;
            Employee employee;
            Console.WriteLine("Enter the number of employees");
            int N = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < N; i++)
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
                        employees.Add(employee);
                        break;

                    case EmployeeType.PartTimeEmp:
                        PartTimeEmployee partEmp = new PartTimeEmployee();
                        employee = partEmp;
                        partEmp.Read();
                        employees.Add(employee);
                        break;
                }
            }

            Console.WriteLine("Before sorting");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{employees[i]}");
            }

            //SELECTION SORTING
            InsertionSort(employees);
            Console.WriteLine("After sorting");
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
