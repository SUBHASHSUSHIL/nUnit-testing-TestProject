using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nUnit_testing_TestProject.Core;

namespace NUnit_Project
{
    [TestFixture]
    public class PrimeUtilityNUnit
    {
        PrimeUtility primeUtility = new PrimeUtility();

        [Test]
        public void IsPrime_WithPrimeNumber_ReturnsTrue()
        {
            var result = primeUtility.IsPrime(5);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPrime_WithNonPrimeNumber_ReturnsFalse()
        {
            var result = primeUtility.IsPrime(4);
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPrime_WithLessThanTwo_ReturnsFalse()
        {
            var result = primeUtility.IsPrime(1);
            var resultZero = primeUtility.IsPrime(0);
            Assert.That(result, Is.False);
            Assert.That(resultZero, Is.False);
        }

        [Test]
        public void IsPrime_WithNegativeNumber_ReturnsFalse()
        {
            var result = primeUtility.IsPrime(-3);
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(7, true)]
        [TestCase(8, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        [TestCase(11, true)]
        public void IsPrime_ShouldCheckIsPrime(int number, bool expectedResult)
        {
            bool result = primeUtility.IsPrime(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ConcatStrings_ShouldConcatenateTwoStrings()
        {
            var result = primeUtility.ConcatStrings("Hello", "World");
            Assert.That(result, Is.EqualTo("Hello World"));
            Assert.That(result, Does.Contain("hello").IgnoreCase);
        }
    }
}