namespace ProjetFormation.Tests;

using NUnit.Framework;
using System;
using ProjetFormation.tuto1;

[TestFixture]
public class CalculatorTests{

        [Test]
        public void Divide_WhenDenominatorIsZero_ShouldThrowDivideByZeroException()
        {
            // Given
            var calculator = new Calculator();
            bool exceptionThrown = false;
            
            try
            {
                // When
                calculator.Divide(10, 0);
                Assert.Fail();
            }
            catch (DivideByZeroException ex)
            {
                // Then
                exceptionThrown = true;
                Assert.AreEqual("Cannot divide by zero.", ex.Message);
            }
            // Assertion outside of catch to ensure exception was thrown
            Assert.IsTrue(exceptionThrown, "Expected DivideByZeroException was not thrown.");
    }

    [Test]
    public void Divide_WhenDenonimatorIsZero_ShouldThrownDivideByZeroEception(){
        // Given
        var calculator = new Calculator();
        // When Then
        Assert.Throws<DivideByZeroException>(()=> calculator.Divide(10,0));
    }
    
}