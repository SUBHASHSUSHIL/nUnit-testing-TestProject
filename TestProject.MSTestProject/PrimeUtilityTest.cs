using nUnit_testing_TestProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MSTestProject
{
    [TestClass]
    public class PrimeUtilityTest
    {
        PrimeUtility primeObject = new PrimeUtility();

        [TestMethod]
        public void IsPrime_WithPrimeNumber_ReturnsTrue()
        {
            var result = primeObject.IsPrime(5);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPrime_WithNonPrimeNumber_ReturnsFalse()
        {
            var result = primeObject.IsPrime(4);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPrime_WithLessThanTwo_ReturnsFalse()
        {
            var result = primeObject.IsPrime(1);
            var resultZero = primeObject.IsPrime(0);
            Assert.IsFalse(result);
            Assert.IsFalse(resultZero);
        }

        [TestMethod]
        public void IsPrime_WithNegativeNumber_ReturnsFalse()
        {
            var result = primeObject.IsPrime(-3);
            Assert.IsFalse(result);
        }
    }
}
