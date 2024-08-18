//10.Class Hierarchy with Method Overriding and Virtual Methods

using System;

class Person
{
    public virtual string DisplayInfo()
    {
        return "Person details.";
    }
}

class Student : Person
{
    public string StudentId { get; set; }
    public string Major { get; set; }

    public Student(string studentId, string major)
    {
        StudentId = studentId;
        Major = major;
    }

    public override string DisplayInfo()
    {
        return $"Student ID: {StudentId}, Major: {Major}";
    }
}

class Teacher : Person
{
    public string EmployeeId { get; set; }
    public string Subject { get; set; }

    public Teacher(string employeeId, string subject)
    {
        EmployeeId = employeeId;
        Subject = subject;
    }

    public override string DisplayInfo()
    {
        return $"Employee ID: {EmployeeId}, Subject: {Subject}";
    }
}

class Program
{
    static void Main()
    {
        Person student = new Student("S123", "Computer Science");
        Console.WriteLine(student.DisplayInfo()); // Output: Student ID: S123, Major: Computer Science

        Person teacher = new Teacher("T456", "Mathematics");
        Console.WriteLine(teacher.DisplayInfo()); // Output: Employee ID: T456, Subject: Mathematics
    }
}
