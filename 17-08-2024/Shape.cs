/*
7.Design a Class Hierarchy with Abstract Classes and Method Overriding
   - Task: Create an abstract class `Shape` with an abstract method `CalculateVolume()`. Derive two classes `Sphere` and `Cube` from `Shape`.
   - Requirements:
     - `Sphere` should have a property `Radius`. Implement `CalculateVolume()` to compute the volume of a sphere.
     - `Cube` should have a property `SideLength`. Implement `CalculateVolume()` to compute the volume of a cube.
   - Example:
     ```csharp
     Shape sphere = new Sphere(5);
Console.WriteLine(sphere.CalculateVolume());

Shape cube = new Cube(3);
Console.WriteLine(cube.CalculateVolume());
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public abstract class Shape
    {
        public abstract double CalculateVolume();
    }

    public class Sphere : Shape
    {
        public double Radius { get; set; }
        public Sphere(int radius)
        {
            Radius = radius;
        }

        public override double CalculateVolume()
        {
            return (4 / 3) * 3.14 * Radius * Radius;
        }

    }

    public class Cube : Shape
    {
        public double SideLength { get; set; }
        public Cube(int sideLength)
        {
            SideLength = sideLength;
        }

        public override double CalculateVolume()
        {
            return (SideLength * SideLength * SideLength);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shape sphere = new Sphere(10);
            Console.WriteLine(sphere.CalculateVolume());

            Shape Cube = new Cube(10);
            Console.WriteLine(Cube.CalculateVolume());
        }
    }
}
