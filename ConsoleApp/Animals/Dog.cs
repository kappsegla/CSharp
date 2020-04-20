using System;

namespace ConsoleApp.Animals
{
    public class Dog : Mammal, IPet
    {
        public override void Talk()
        {
            Console.WriteLine("Voff");
        }


        public bool IsHungry()
        {
            return false;
        }
    }
}