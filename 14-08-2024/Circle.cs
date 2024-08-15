//class Circle

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    internal class Circle
    {
        public double Radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Circumference()
        {
            return 2 * 3.14 * Radius;
        }

        public bool isCircumferenceGT(Circle other)
        {
            return Circumference() > other.Circumference();
        }

        public bool isCircumferenceLT(Circle other)
        {
            return Circumference() < other.Circumference();
        }
        public bool isCircumferenceEQ(Circle other)
        {
            return Circumference() == other.Circumference();
        }

        public override string ToString()
        {
            return $"Circle with radius {Radius}";
        }
    }
}


//Main()

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius of first circle");
            double r1= double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the radius of Second circle");
            double r2 = double.Parse(Console.ReadLine());
            Circle c1 = new Circle(r1);
            Circle c2 = new Circle(r2);

            if(c1.isCircumferenceGT(c2))
            {
                Console.WriteLine($"The {c1} has greater circumferece than {c2}");
            }
            else if (c2.isCircumferenceGT(c1))
            {
                Console.WriteLine($"The {c2} has greater circumferece than {c1}");
            }
            else if (c1.isCircumferenceEQ(c2))
            {
                Console.WriteLine($"The {c2} has same circumferece as {c1}");
            }


        }
    }
}

