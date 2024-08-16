//RationalNumber class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    class MyUtil
    {
        public static int FindGCD(int a, int b) //HCF
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // Use the Euclidean algorithm
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
    public class RationalNumber
    {
        public int Numerator { get; set; }
        private int denominator;
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (denominator == 0)
                {
                    denominator = 1;
                }
                denominator = value;
            }
        }

        public RationalNumber(int _numerator, int _denominator)
        {
            // throw ERR this.Denominator = 0
            this.Numerator = _numerator;
            this.Denominator = _denominator;
        }
        public RationalNumber Add(RationalNumber other)
        {
            RationalNumber sum = new RationalNumber(0, 0);
            sum.Numerator = (this.Numerator * other.Denominator) + (other.Numerator * this.Denominator);
            sum.Denominator = this.Denominator * other.Denominator;
            int gcd = MyUtil.FindGCD(sum.Numerator, sum.Denominator);
            sum.Numerator = sum.Numerator / gcd;
            sum.Denominator = sum.Denominator / gcd;

            return sum;
        }

        public RationalNumber Sub(RationalNumber other)
        {
            RationalNumber sub = new RationalNumber(0, 0);
            sub.Numerator =Math.Abs((this.Numerator * other.Denominator) - (other.Numerator * this.Denominator));
            sub.Denominator = this.Denominator * other.Denominator;
            int gcd = MyUtil.FindGCD(sub.Numerator, sub.Denominator);
            sub.Numerator = sub.Numerator / gcd;
            sub.Denominator = sub.Denominator / gcd;

            return sub;
        }

        public RationalNumber Mul(RationalNumber other)
        {
            RationalNumber mul = new RationalNumber(0, 0);
            mul.Numerator = this.Numerator * other.Numerator;
            mul.Denominator = this.Denominator * other.Denominator;
            int gcd = MyUtil.FindGCD(mul.Numerator, mul.Denominator);
            mul.Numerator = mul.Numerator / gcd;
            mul.Denominator = mul.Denominator / gcd;

            return mul;

        }

        public RationalNumber Div(RationalNumber other)
        {
            RationalNumber div = new RationalNumber(0, 0);
            int reciprocalNum = other.Denominator;
            int reciprocalDen = other.Numerator;
            div.Numerator = this.Numerator * reciprocalNum;
            div.Denominator = this.Denominator * reciprocalDen;
            int gcd = MyUtil.FindGCD(div.Numerator, div.Denominator);
            div.Numerator = div.Numerator / gcd;
            div.Denominator = div.Denominator / gcd;

            return div;

        }

        public bool isEQ(RationalNumber other)
        {
            return (this.Numerator * other.Denominator) == (other.Numerator * this.Denominator);


        }

        public bool isGT(RationalNumber other)
        {
            return (this.Numerator * other.Denominator) > (other.Numerator * this.Denominator);

        }

        public bool isLT(RationalNumber other)
        {
            return (this.Numerator * other.Denominator) < (other.Numerator * this.Denominator);

        }





        public override string ToString()
        {
            return $"[{Numerator} / {Denominator}]";
        }
    }
}


//Main()


using System;

namespace RationalNumber
{
    
    internal class TestComplexNumber
    {
        static void Main(string[] args)
        {
            RationalNumber firstNo = new RationalNumber(10, 20);
            RationalNumber secondNo = new RationalNumber(5, 10);
            RationalNumber sum = firstNo.Add(secondNo);
            RationalNumber sub = firstNo.Sub(secondNo);
            RationalNumber mul = firstNo.Mul(secondNo);
            RationalNumber div = firstNo.Div(secondNo);

            

            Console.WriteLine($"{firstNo} + {secondNo} = {sum}");
            Console.WriteLine($"{firstNo} - {secondNo} = {sub}");
            Console.WriteLine($"{firstNo} * {secondNo} = {mul}");
            Console.WriteLine($"{firstNo} / {secondNo} = {div}");



            if (firstNo.isEQ(secondNo))
            {
                Console.WriteLine($"Both rational numbers {firstNo} and {secondNo} are same");
            }
            else if (firstNo.isGT(secondNo))
            {
                Console.WriteLine($"{firstNo} is greater than {secondNo}");
            }
            else if (firstNo.isLT(secondNo))
            {
                Console.WriteLine($"{firstNo} is less than {secondNo}");
            }

        }
    }
}
