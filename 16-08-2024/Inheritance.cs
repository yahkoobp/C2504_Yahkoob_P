using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }
    }

    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("Meowing...");
        }
    }

    public class Puppy : Dog
    {
        public void Weep()
        {
            Console.WriteLine("Weeping...");
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {

            //single inheritance
            //Dog willow = new Dog();
            //willow.Eat();
            //willow.Bark();

            //multilevel inheritance
            //Puppy p = new Puppy();
            //p.Eat();
            //p.Bark();
            //p.Weep();
            
            //Hierarchical inheritance
            Cat c = new Cat();
            c.Eat();
            c.Meow();
        }
    }
}
