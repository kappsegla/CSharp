using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.TestExample
{
    public class DemoTest
    {
        private bool _internalState;
        private int _counter;
        
        //This is a pure function, easy to write a test for.
        public int FindLargestNumber(IEnumerable<int> numbers)
        {
            return numbers.Max();
        }

        //A method with side effects, for testing this we must be able to check the side effects before and after.
        public void InternalStateChanger(bool value)
        {
            _internalState = value;
            _counter++;
        }

        //Maybe we have a method with a behavior that changes depending on state. Assert the behavior then
        public int ReturnDependingOnState()
        {
            if (_internalState)
                return 1;
            else
            {
                return 0;
            }
        }

        public int Counter
        {
            get => _counter;
            set => _counter = value;
        }

        //If only way of asserting void methods is thru checking values on the object after.
        public bool InternalState
        {
            get => _internalState;
            set => _internalState = value;
        }
    }
}