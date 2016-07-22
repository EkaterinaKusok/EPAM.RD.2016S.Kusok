using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Test Driven Development
namespace Sequence.Tests
{
    [TestClass]
    public class SequenseTests
    {
        [TestMethod]
        public void GetSequence_LimitIsZero_ReturnAnEmptyArray() // A-A-A Arrange Act Assert
        {
            // Act
            var result = Sequence.GetSequence(0);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSequence_LimitIsMinusOne_ThrowAnExeption() 
        {
            var result = Sequence.GetSequence(-1);
        }

        [TestMethod]
        public void GetSequence_LimitIsOne_ReturnsArrayWithOneElement() 
        {
            var result = Sequence.GetSequence(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0]);
        }
    }
}
