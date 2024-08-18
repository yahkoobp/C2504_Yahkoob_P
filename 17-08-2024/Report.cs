/* 
 3. Create an Abstract Base Class with a Template Method
   - Task: Implement an abstract class `Report` with a method `GenerateReport()` that calls two methods `CreateHeader()` and `CreateBody()`. Derive classes `AnnualReport` and `MonthlyReport` from `Report`.
   - Requirements:
     - `AnnualReport` should override `CreateHeader()` and `CreateBody()` to provide a header and body for an annual report.
     - `MonthlyReport` should override `CreateHeader()` and `CreateBody()` to provide a header and body for a monthly report.
   - Example:
     ```csharp
     Report annual = new AnnualReport();
     annual.GenerateReport(); // Output: Annual report header and body

     Report monthly = new MonthlyReport();
     monthly.GenerateReport(); // Output: Monthly report header and body
     ```
*/

using System;

abstract class Report
{
    public void GenerateReport()
    {
        CreateHeader();
        CreateBody();
        CreateFooter();
    }

    protected abstract void CreateHeader();
    protected abstract void CreateBody();
    protected virtual void CreateFooter()
    {
        Console.WriteLine("Creating footer...");
    }
}

class AnnualReport : Report
{
    protected override void CreateHeader()
    {
        Console.WriteLine("Creating annual report header...");
    }

    protected override void CreateBody()
    {
        Console.WriteLine("Creating annual report body...");
    }
}

class MonthlyReport : Report
{
    protected override void CreateHeader()
    {
        Console.WriteLine("Creating monthly report header...");
    }

    protected override void CreateBody()
    {
        Console.WriteLine("Creating monthly report body...");
    }
}

class Program
{
    static void Main()
    {
        Report annual = new AnnualReport();
        annual.GenerateReport();
        // Output: Creating annual report header...
        //         Creating annual report body...
        //         Creating footer...

        Report monthly = new MonthlyReport();
        monthly.GenerateReport();
        // Output: Creating monthly report header...
        //         Creating monthly report body...
        //         Creating footer...
    }
}
