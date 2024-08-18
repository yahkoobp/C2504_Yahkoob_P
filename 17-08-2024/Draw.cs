/* 
  2.Design a Class Hierarchy with Interfaces
   - Task: Create an interface `IDrawable` with a method `Draw()`. Create a base class `Graphic` that implements `IDrawable` and has a method `Resize()`. Derive two classes `Line` and `Polygon` from `Graphic`.
   - Requirements:
     - `Line` should have properties `StartPoint` and `EndPoint`. Implement the `Draw()` method to draw a line.
     - `Polygon` should have a property `Vertices` (a list of points). Implement the `Draw()` method to draw a polygon.
     - Implement the `Resize()` method in both derived classes to adjust their dimensions.
   - Example:
     ```csharp
     IDrawable line = new Line(new Point(0, 0), new Point(10, 10));
     line.Draw(); // Draws a line from (0,0) to (10,10)

     Graphic polygon = new Polygon(new List<Point> { new Point(0, 0), new Point(10, 0), new Point(10, 10), new Point(0, 10) });
     polygon.Resize(2); // Resize polygon
     polygon.Draw(); // Draws the resized polygon
*/




using System;
using System.Collections.Generic;

interface IDrawable
{
    void Draw();
    void Resize();
}

abstract class Graphic : IDrawable
{
    public abstract void Draw();

    public abstract void Resize();
}

class Line : Graphic
{
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Line(Point startPoint, Point endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing line from {StartPoint} to {EndPoint}");
    }
    public override void Resize()
    {
        Console.WriteLine("Resizing line.....");
    }
}

class Polygon : Graphic
{
    public List<Point> Vertices { get; set; }

    public Polygon(List<Point> vertices)
    {
        Vertices = vertices;
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing polygon with vertices:");
        foreach (var vertex in Vertices)
        {
            Console.WriteLine(vertex);
        }
    }

    public override void Resize()
    {
        Console.WriteLine("Resizing polygon.......");
    }
}

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Program
{
    static void Main()
    {
        IDrawable line = new Line(new Point(0, 0), new Point(10, 10));
        line.Draw();
        line.Resize();
        // Output: Drawing line from (0,0) to (10,10)

        IDrawable polygon = new Polygon(new List<Point> { new Point(0, 0), new Point(10, 0), new Point(10, 10), new Point(0, 10) });
         // Resize polygon (method can be implemented)
        polygon.Draw();
        polygon.Resize();// Output: Drawing polygon with vertices: (0,0) (10,0) (10,10) (0,10)
    }
}
