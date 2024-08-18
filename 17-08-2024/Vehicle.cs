/*
    4.Design a Class Hierarchy with Abstract Methods and Interfaces
   - Task: Create an abstract class `Vehicle` with an abstract method `Drive()`. Create an interface `IFuel` with a method `Refuel()`. Derive classes `Car` and `Motorcycle` from `Vehicle` and implement `IFuel`.
   - Requirements:
     - `Car` should have properties `FuelLevel` and `TankCapacity`. Implement the `Drive()` method to simulate driving and `Refuel()` to refill the tank.
     - `Motorcycle` should have properties `FuelLevel` and `TankCapacity`. Implement the `Drive()` method to simulate driving and `Refuel()` to refill the tank.
   - Example:
     ```csharp
     Vehicle car = new Car(10, 50);
car.Drive(); // Output: Car is driving
(car as IFuel).Refuel(20); // Output: Car is refueled

Vehicle motorcycle = new Motorcycle(5, 15);
motorcycle.Drive(); // Output: Motorcycle is driving
(motorcycle as IFuel).Refuel(10); // Output: Motorcycle is refueled
*/

using System;

interface IFuel
{
    void Refuel(decimal amount);
}

abstract class Vehicle : IFuel
{
    public abstract void Drive();

    public abstract void Refuel(decimal amount);
}

class Car : Vehicle
{
    public decimal FuelLevel { get; set; }
    public decimal TankCapacity { get; set; }

    public Car(decimal fuelLevel, decimal tankCapacity)
    {
        FuelLevel = fuelLevel;
        TankCapacity = tankCapacity;
    }

    public override void Drive()
    {
        Console.WriteLine("Car is driving");
    }

    public override void Refuel(decimal amount)
    {
        FuelLevel = Math.Min(FuelLevel + amount, TankCapacity);
        Console.WriteLine("Car is refueled");
    }
}

class Motorcycle : Vehicle
{
    public decimal FuelLevel { get; set; }
    public decimal TankCapacity { get; set; }

    public Motorcycle(decimal fuelLevel, decimal tankCapacity)
    {
        FuelLevel = fuelLevel;
        TankCapacity = tankCapacity;
    }

    public override void Drive()
    {
        Console.WriteLine("Motorcycle is driving");
    }

    public override void Refuel(decimal amount)
    {
        FuelLevel = Math.Min(FuelLevel + amount, TankCapacity);
        Console.WriteLine("Motorcycle is refueled");
    }
}

class Program
{
    static void Main()
    {
        Vehicle car = new Car(10, 50);
        car.Drive(); // Output: Car is driving
        car.Refuel(20); // Output: Car is refueled

        Vehicle motorcycle = new Motorcycle(5, 15);
        motorcycle.Drive(); // Output: Motorcycle is driving
        motorcycle.Refuel(10); // Output: Motorcycle is refueled
    }
}
