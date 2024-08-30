using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int BasePay { get; set; }
        public int Age { get; set; }

    }

    public class Employees
    {
        public Employee[] employees {  get; set; } 

        public Employee this [int index]
        {
            get => employees[index];
            set 
            {
                employees[index] = value; 
            }
        }

        public Employee getHighestSalary()
        {
            Employee maxSalaryEmp = null;
            int maxSalary = int.MinValue;
            foreach (Employee employee in employees)
            {
                if(employee.BasePay > maxSalary)
                {
                    maxSalaryEmp = employee;
                    maxSalary = employee.BasePay;
                }
            }

            return maxSalaryEmp;
        }

        public int getTwelveMonthSalary(Employee emp)
        {
            return emp.BasePay * 12;
        }

        public Employee GetYoungEmployee()
        {
            int minAge = int.MaxValue;
            Employee minAgeEmp = null;
            foreach (Employee employee in employees)
            {
                if (employee.Age < minAge)
                {
                    minAgeEmp = employee;
                    minAge = employee.Age;
                }
            }
            return minAgeEmp;
        }

        public int NumberOfEmployeeOfGivenAge(int age)
        {
            int c = 0
            foreach (Employee employee in employees)
            {
                if(employee.Age == age)
                {
                    c++;
                }
            }

            return c;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employees employees = new Employees();
            //employees[0] = new Employee { Name :"Yahkoob" ,}
        }
    }
}
