using System;


namespace RectanglesAreaComparison
{
    internal class Class1
    {
        
        class RectangleV2
        {
            public int Length { get; set; }
            public int Breadth { get; set; }

            public RectangleV2(int length, int breadth)
            {
                this.Length = length;
                this.Breadth = breadth;
            }
            public override string ToString()
            {
                return $"[Length={this.Length}, Breadth={this.Breadth}, Area={this.FindArea()}]";
            }
            public int FindArea()
            {
                return this.Length * this.Breadth;
            }
            public bool IsAreaGreaterThan(RectangleV2 other)
            {
                return FindArea() > other.FindArea();
            }
            public bool IsAreaEqual(RectangleV2 other)
            {
                return FindArea() == other.FindArea();
            }
          
            public bool IsAreaLessThan(RectangleV2 second)
            {
                RectangleV2 first = this;
                return first.FindArea() > second.FindArea();
            }
        }

        static void Main(string[] args)
        {
            RectangleV2 first = new RectangleV2(10, 25);
            RectangleV2 second = new RectangleV2(20, 15);
            if (first.IsAreaGreaterThan(second))
            {
                Console.WriteLine($"First Land {first} is greater than Second Land{second}");
            }
            else if (first.IsAreaEqual(second))
            {
                Console.WriteLine("Equal areas");
            }
            else
            {
                Console.WriteLine($"Second Land {second} is greater than First Land{first}");
            }
        }
    }
}
