using System.Timers;

namespace ConsoleApp.Patterns
{
    public class PatternExamples
    {
        public void Run()
        {
            //  House house = new House(){Doors = 1, HasSwimmingPool = true};
           // var builder = new HouseBuilder();
            var house = HouseBuilder.GetBuilder()
                .Rooms(2)
                .Doors(1)
                .Windows(4)
                .HasPool()
                .Build();

            var bungalow = HouseBuilder.GetBuilder()
                .CreateBungalow()
                .HasPool()
                .Build();
        }
    }
}