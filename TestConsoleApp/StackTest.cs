using System;
using Xunit;
using ConsoleApp.TestExample;

namespace TestConsoleApp
{
    // Expectations List
    //      Context: Empty Stack
    //          Verify that Count is 0
    //          Call Pop, Verify InvalidOperationException is thrown
    //          Call Peek, Verify InvalidOperationException is thrown
    //          Call Contains, Verify that it returns false
    //
    //      Context: Create a Stack, Push an Integer
    //          Verify that Count is 1
    //          Call Pop, Verify Count is 0
    //          Call Peek, Verify Count is 1
    //          Call Pop, Verify Pop returns the pushed integer
    //          Call Peek, Verify Peek returns the pushed integer
    //
    //      Context: Create a Stack, Push Multiple Integers
    //          Push 3 ints, verify that Count is 3
    //          Push 3 ints 10, 20, 30, Call Pop three times, verify that they are removed 30, 20, 10
    //          Create a Stack, Push(10), Push(20), Push(30), call Contains(20), verify that it returns true
    //
    //      Context: Create a Stack<string>
    //          Push("Help"), call Pop, verify that what is returned from Pop equals "Help"


    public class StackTest
    {
        public class EmptyStack
        {
            private Stack<int> stack;

            public EmptyStack()
            {
                stack = new Stack<int>();
            }

            [Fact]
            public void Count_ShouldReturnZero()
            {
                var count = stack.Count();

                Assert.Equal(0, count);
            }

            [Fact]
            public void Pop_ShouldReturnInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(() => stack.Pop());
            }

            [Fact]
            public void Peek_ShouldReturnInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(() => stack.Peek());
            }

            [Fact]
            public void Contains_ReturnsFalse()
            {
                var result = stack.Contains(10);

                Assert.False(result);
            }
        }

        public class StackWithOneElement
        {
            private Stack<int> stack;
            private int pushedValue = 42;

            public StackWithOneElement()
            {
                stack = new Stack<int>();
                stack.Push(pushedValue);
            }

            [Fact]
            public void Count_ShouldBeOne()
            {
                int count = stack.Count();

                Assert.Equal(1, count);
            }

            [Fact]
            public void Pop_CountShouldBeZero()
            {
                stack.Pop();
                int count = stack.Count();

                Assert.Equal(0, count);
            }

            [Fact]
            public void Peek_CountShouldBeOne()
            {
                stack.Peek();

                int count = stack.Count();

                Assert.Equal(1, count);
            }

            [Fact]
            public void Pop_ShouldReturnPushedValue()
            {
                int actual = stack.Pop();

                Assert.Equal(pushedValue, actual);
            }

            [Fact]
            public void Peek_ShouldReturnPushedValue()
            {
                int actual = stack.Peek();

                Assert.Equal(pushedValue, actual);
            }
        }

        public class StackWithThreeElements
        {
            private Stack<int> stack;
            const int firstPushedValue = 10;
            const int secondPushedValue = 20;
            const int thirdPushedValue = 30;

            public StackWithThreeElements()
            {
                stack = new Stack<int>();
                stack.Push(firstPushedValue);
                stack.Push(secondPushedValue);
                stack.Push(thirdPushedValue);
            }

            [Fact]
            public void Count_ShouldBeThree()
            {
                int count = stack.Count();

                Assert.Equal(3, count);
            }

            [Fact]
            public void Pop_VerifyLifoOrder()
            {
                Assert.Equal(thirdPushedValue, stack.Pop());
                Assert.Equal(secondPushedValue, stack.Pop());
                Assert.Equal(firstPushedValue, stack.Pop());
            }

            [Fact]
            public void Peek_ReturnsLastPushedValue()
            {
                int actual = stack.Peek();
                Assert.Equal(thirdPushedValue, actual);
            }

            [Fact]
            public void Contains_ReturnsTrue()
            {
                bool contains = stack.Contains(secondPushedValue);

                Assert.True(contains);
            }
        }

        public class StackWithString
        {
            [Fact]
            public void Pop_ShouldReturnPushedValue()
            {
                Stack<string> stack = new Stack<string>();
                stack.Push("TestString");

                string actual = stack.Pop();

                Assert.Equal("TestString", actual);
            }
        }
    }
}