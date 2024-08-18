/*6.Implement a Class Hierarchy with Abstract Methods and Interfaces
   - Task: Create an abstract class `Appliance` with an abstract method `Operate()`. Create an interface `IEnergyEfficient` with a method `GetEnergyEfficiency()`. Derive two classes `WashingMachine` and `Refrigerator` from `Appliance` and implement `IEnergyEfficient`.
   - Requirements:
     - `WashingMachine` should have properties `LoadCapacity` and `WaterUsage`. Implement `Operate()` to simulate operation and `GetEnergyEfficiency()` to return energy efficiency details.
     - `Refrigerator` should have properties `Temperature` and `CoolingCapacity`. Implement `Operate()` to simulate operation and `GetEnergyEfficiency()` to return energy efficiency details.
   - Example:
     ```csharp
     Appliance washer = new WashingMachine(7, 50);
washer.Operate();
Console.WriteLine(((IEnergyEfficient)washer).GetEnergyEfficiency());

Appliance fridge = new Refrigerator(-5, 300);
fridge.Operate();
Console.WriteLine(((IEnergyEfficient)fridge).GetEnergyEfficiency());
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliance.cs
{
    interface IEnergyEfficient
    {
        void GetEnergyEfficiency();
    }

    public abstract class Appliance
    {
        public abstract void Operate();
      
    }

    public class WashingMachine : Appliance ,IEnergyEfficient
    {

        public int LoadCapacity {  get; set; }
        public int WaterUsage { get; set; }

        public WashingMachine(int loadCapacity, int waterUsage)
        {
            LoadCapacity = loadCapacity;
            WaterUsage = waterUsage;
        }

        public override void Operate()
        {
            Console.WriteLine("Washing machine is operating.....");
        }
        public void GetEnergyEfficiency()
        {
            Console.WriteLine($"Washing machine is working with load capacity{LoadCapacity} and water usage {WaterUsage}");
        }
    }

    public class Refregirator : Appliance ,IEnergyEfficient
    {
        public int Temperature {  get; set; }
        public int CoolingCapacity {  get; set; }

        public Refregirator(int temperature, int coolingCapacity)
        {
            Temperature = temperature;
            CoolingCapacity = coolingCapacity;
        }

        public override void Operate()
        {
            Console.WriteLine("Referegirator is operating......");
        }

        public void GetEnergyEfficiency()
        {
            Console.WriteLine($"Referigerator is working with temperature {Temperature} and cooling capacity {CoolingCapacity}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Appliance wash = new WashingMachine(100, 200);
            wash.Operate();
            ((IEnergyEfficient)wash).GetEnergyEfficiency();

            Appliance rf = new Refregirator(43, 100);
            rf.Operate();
            ((IEnergyEfficient)rf).GetEnergyEfficiency();
        }
    }
}
