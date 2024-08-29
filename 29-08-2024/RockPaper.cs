using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        enum Items
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        static void Main(string[] args)
        {
            var items = new string[] { "Rock", "Paper", "Scissors" };
            Random rand = new Random();
            int userPoint = 0;
            int compPoint = 0;
            
            //Console.WriteLine(rand.Next(0,3));
            while (true)
            {
                Console.WriteLine("Enter your item");
                Console.WriteLine("1.Rock 2.Paper 3.Scissors");
                Items choice = (Items)int.Parse(Console.ReadLine());
                int compIndex = rand.Next(0, 3);

                switch (choice)
                {
                case Items.Rock:
                    Console.WriteLine($"Computer selected {items[compIndex]}");
                    if (compIndex == 2)
                    {
                         Console.WriteLine($"You got the point");
                         userPoint++;
                    }
                    else if (compIndex == 1)
                    {
                         Console.WriteLine($"Computer got the point");
                         compPoint++;
                    }
                    else if (items[compIndex] ==  items[compPoint])
                    {
                         Console.WriteLine("Same items selected...");
                    }
                    break;

                case Items.Paper:
                    Console.WriteLine($"Computer selected {items[compIndex]}");
                    if (compIndex == 0)
                    {
                          Console.WriteLine($"You got the point");
                          userPoint++;
                    }
                    else if (compIndex == 3)
                    {
                          Console.WriteLine($"Computer got the point");
                          compPoint++;
                    }
                    else if(items[compIndex] == items[compPoint])
                    {
                          Console.WriteLine("Same items selected...");
                    }
                     break;

                case Items.Scissors:
                    Console.WriteLine($"Computer selected {items[compIndex]}");
                    if (compIndex == 2)
                    {
                           Console.WriteLine($"You got the point ");
                           userPoint++;
                    }
                    else if (compIndex == 0)
                    {
                           Console.WriteLine($"Computer got the point");
                           compPoint++;
                    }
                    else if(items[compIndex] == items[compPoint])
                    {
                          Console.WriteLine("Same items selected...");
                    }
                    break;
                }

                if (compPoint == 10 || userPoint == 10)
                {
                    break;
                }

            } 

            if (compPoint == 10)
            {
                Console.WriteLine("The computer is the winner");
            }
            else
            {
                Console.WriteLine("You are the winner");
            }

        }
    }
}
