using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpArray
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
        static void SelectionSort(Employee[] emp)
        {
            int l = emp.Length;
            for (int i = 0; i < l; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < l; j++)
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
                EmployeeType empType;
                Employee employee;
                Console.WriteLine("Enter the number of employees");
                int N = int.Parse(Console.ReadLine());
                Employee[] employees = new Employee[N];
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
                            employees[i] = employee;
                            break;

                        case EmployeeType.PartTimeEmp:
                            PartTimeEmployee partEmp = new PartTimeEmployee();
                            employee = partEmp;
                            partEmp.Read();
                            employees[i] = employee;
                            break;
                    }
                }

                Console.WriteLine("Before sorting");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"{employees[i]}");
                }

            //SELECTION SORTING
            SelectionSort(employees);
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
