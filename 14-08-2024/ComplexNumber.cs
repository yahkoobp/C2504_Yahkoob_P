//class ComplexNumber

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    internal class ComplexNumber
    {
        public int Real {  get; set; }
        public int Imaginary { get; set; }

        public ComplexNumber(int real , int imaginary) 
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public ComplexNumber AddComplexNumber(ComplexNumber other)
        {
             ComplexNumber result = new ComplexNumber(0,0);
             result.Real = this.Real + other.Real;
             result.Imaginary = this.Imaginary + other.Imaginary;
             return result;
        }

        public override string ToString()
        {
            return $"{Real} + i{Imaginary}";
        }
    }
}

//Main()

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber cn1 = new ComplexNumber(3 , 4);
            ComplexNumber cn2 = new ComplexNumber(5, 3);
            ComplexNumber result = cn1.AddComplexNumber(cn2);
            Console.WriteLine($"The resultant complex number after addition is {result}");

        }
    }
}

