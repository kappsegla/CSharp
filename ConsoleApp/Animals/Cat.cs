using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Animals
{
    class Cat : Mammal, IPet, IComparable<Cat>
    {
        public int Weight { get; set; }
        
        public override void Talk()
        {
            Console.WriteLine("Mjau");
        }

        public bool IsHungry()
        {
            return true;
        }

        public int CompareTo(Cat other)
        {
            if (other == null)
                return 1;
            
            if (Weight > other.Weight)
                return 1;
            if (Weight < other.Weight)
                return -1;
            return 0;
        }
    }
}
