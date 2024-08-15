//CricketGroundV2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGroundV2
{
    internal class CricketGround
    {
        public int LegSide;
        public int OffSide;
        public int Straight;
        public int ThirdMan;

        public CricketGround(int legSide, int offSide, int straight, int thirdMan)
        {
            this.LegSide = legSide;
            this.OffSide = offSide;
            this.Straight = straight;
            this.ThirdMan = thirdMan;
        }

        public int getMinimum()
        {
            int minLegOff ,minStraightThird , minimum;
            if (LegSide < OffSide)
            {
                minLegOff = LegSide;
            }
            else
            {
                minLegOff = OffSide;
            }

            if (Straight < ThirdMan)
            {
                minStraightThird = Straight;
            }
            else
            {
                minStraightThird = ThirdMan;
            }

            if (minLegOff < minStraightThird)
            {
                minimum = minLegOff;
            }
            else
            {
                minimum = minStraightThird;
            }

            return minimum;

        }

        public bool IsShortestDistanceGt(CricketGround other)
        {
            return this.getMinimum() > other.getMinimum();
        }
        public bool IsShortestDistanceLt(CricketGround other)
        {
            return this.getMinimum() < other.getMinimum();
        }
        public bool IsShortestDistanceEq(CricketGround other)
        {
            return this.getMinimum() == other.getMinimum();
        }
    }
}

//Main()

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricketGroundV2;

namespace CricketGroundV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CricketGround g1 = new CricketGround(70 , 35 , 54 , 63);
            CricketGround g2 = new CricketGround(57, 35, 73, 54);
            
            if(g1.IsShortestDistanceLt(g2))
            {
                Console.WriteLine("First cricket is better than the second");
            }
            else if(g2.IsShortestDistanceLt(g1))
            {
                Console.WriteLine("Second ground is better than first");
            }

            else if (g1.IsShortestDistanceEq(g2))
            {
                Console.WriteLine("Both grounds minimum distances are equal");
            }

        }
    }
}

