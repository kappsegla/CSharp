using ConsoleApp.TestExample;
using Xunit;

namespace TestConsoleApp
{
     public class CalculatorTest
    {
        [Fact]
        void ChangeSomethingIncrementsValueByOne()
        {
            var calculator = new Calculator();
            var current = calculator.GetSomething();
            
            calculator.ChangeSomething();
            
            Assert.Equal(current + 1,calculator.GetSomething());
        }
        
        [Fact]
        void CallToIsEvenWithEvenNumberReturnsTrue()
        {
            //Arrange
            int value = 2;
            //Act
            var result = Calculator.IsEven(2);
            //Assert
            Assert.True(result);
        }

        [Fact]
        void CallToIsEvenWithOddNumberReturnsFalse()
        {
            //Arrange
            int value = 1;
            //Act
            var result = Calculator.IsEven(value);
            //Assert
            Assert.False(result);
        }
        
        
        [Fact]
        public void PassingTest()
        {
            var result = Calculator.Add(2, 2);
            
            Assert.Equal(4, result);
        }

        // [Fact]
        // public void FailingTest()
        // {
        //     Assert.Equal(5, Calculator.Add(2,2));
        // }
    }
}