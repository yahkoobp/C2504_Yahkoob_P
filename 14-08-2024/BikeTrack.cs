//class BikeTrack

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeTrack
{
    internal class BikeTrack
    {
        public int Distance { get; set; }
        public BikeTrack(int distance) 
        { 
            this.Distance = distance;
        }

        public bool IsGt(BikeTrack other)
        {
            return Distance > other.Distance;
        }
        public bool IsLt(BikeTrack other)
        {
            return Distance < other.Distance;
        }
        public bool IsEq(BikeTrack other)
        {
            return Distance == other.Distance;
        }

        public override string ToString()
        {
            return $"The bike track with {Distance}";
        }


    }
}

//Main()

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeTrack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the distance of first bike track");
            int d1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the distance of Second track");
            int d2 = int.Parse(Console.ReadLine());
            BikeTrack t1 = new BikeTrack(d1);
            BikeTrack t2 = new BikeTrack(d2);

            if (t1.IsGt(t2))
            {
                Console.WriteLine($"The {t1} has greater circumferece than {t2}");
            }
            else if (t2.IsGt(t1))
            {
                Console.WriteLine($"The {t2} has greater circumferece than {t1}");
            }
            else if (t1.IsEq(t2))
            {
                Console.WriteLine($"The {t1} has same circumferece as {t2}");
            }
        }
    }
}

