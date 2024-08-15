//class CricketGround

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGroundV1.cs
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

        public bool CompareLegSide(CricketGround other)
        {
            return this.LegSide < other.LegSide;
        }

        public bool CompareOffSide(CricketGround other)
        {
            return this.OffSide < other.OffSide;
        }
        public bool CompareStraight(CricketGround other)
        {
            return this.Straight < other.Straight;
        }
        public bool CompareThirdMan(CricketGround other)
        {
            return this.ThirdMan < other.ThirdMan;
        }
    }
}

//Main

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGroundV1.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CricketGround g1 = new CricketGround(70, 65, 59, 65);
            CricketGround g2 = new CricketGround(65, 75, 69, 59);
            bool running = true;
            bool result = false;
            string positionName = "";
            while (running)
            {
                bool isExit = false;
                Console.WriteLine("Enter the position you are looking");
                Console.WriteLine("1.LegSide");
                Console.WriteLine("2.OffSide");
                Console.WriteLine("3.Straight");
                Console.WriteLine("4.ThirdMan");
                Console.WriteLine("0.EXIT");
                string position = Console.ReadLine();
                
                
                switch (position)
                {
                    case "1":
                        result = g1.CompareLegSide(g2);
                        positionName = "LegSide";
                        break;

                    case "2":
                        result = g1.CompareOffSide(g2);
                        positionName = "OffSide";
                        break;

                    case "3":
                        result = g1.CompareStraight(g2);
                        positionName = "Straight";
                        break;

                    case "4":
                        result = g1.CompareThirdMan(g2);
                        positionName = "ThirdMan";
                        break;

                    case "0":
                        running = false;
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        isExit = true;
                        break;
                }

                if (!isExit)
                {

                    if (result)
                    {
                        Console.WriteLine($"First cricket ground is better for the position {positionName}");
                    }
                    else
                    {
                        Console.WriteLine($"Second cricket ground is better for the position {positionName}");
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

