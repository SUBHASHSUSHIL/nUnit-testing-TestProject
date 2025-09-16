using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project
{
    [TestFixture]
    public class AssertionTypes
    {
        private List<string> _fruits;
        private Dictionary<string, int> _ages;
        private People _person;

        [SetUp]
        public void Setup()
        {
            _fruits = new List<string> { "Apple", "Banana", "Cherry" };
            _ages = new Dictionary<string, int>
            {
                { "Alice", 30 },
                { "Bob", 25 },
                { "Charlie", 35 }
            };
            _person = new People
            {
                Name = "John Doe",
                Age = 28,
                Email = "john@gmail.com"
            };
        }

        [Test]
        public void EqualityAssertion()
        {
            string actual = "Hello World";
            int number = 42;

            Assert.That(actual, Is.EqualTo("Hello World"));
            Assert.That(number, Is.EqualTo(42));
            Assert.That(number, Is.Not.EqualTo(100));
            Assert.That(actual, Is.Not.EqualTo("Goodbye World"));
            Assert.That(actual, Is.EqualTo("hello world").IgnoreCase);
            Assert.That(actual.Length, Is.EqualTo(11));
        }

        [Test]
        public void NumericAssertions()
        {
            double value = 5.5;
            int number = 7;

            Assert.That(value, Is.GreaterThan(5));
            Assert.That(value, Is.GreaterThanOrEqualTo(5.5));
            Assert.That(value, Is.LessThan(6));
            Assert.That(number, Is.LessThanOrEqualTo(7));
            Assert.That(value, Is.InRange(5, 9));
        }

        [Test]
        public void StringAssertions()
        {
            string message = "NUnit is a unit-testing framework for .NET";
            Assert.That(message, Does.StartWith("NUnit"));
            Assert.That(message, Does.EndWith(".NET"));
            Assert.That(message, Does.Contain("unit-testing"));
            Assert.That(message, Does.Match(@"NUnit.*\.NET"));
            Assert.That(message, Does.Not.Contain("Java"));
            Assert.That(message.ToLower(), Is.EqualTo(message.ToLower()).IgnoreCase);
        }

        [Test]
        public void CollectionAssertions()
        {
            Assert.That(_fruits.Count, Is.EqualTo(3));
            Assert.That(_fruits, Has.Count.EqualTo(3));
            Assert.That(_fruits, Does.Contain("Apple"));
            Assert.That(_fruits, Has.No.Member("Grapes"));
            Assert.That(_fruits, Is.Ordered);
            Assert.That(_fruits, Is.Unique);
        }

        [Test]
        public void DictionaryAssertions()
        {
            Assert.That(_ages, Has.Count.EqualTo(3));
            Assert.That(_ages, Contains.Key("Alice"));
            Assert.That(_ages, Does.Not.ContainKey("David"));
            Assert.That(_ages, Contains.Value(25));
            Assert.That(_ages, Does.Not.ContainValue(40));
        }

        [Test]
        public void TypeAssertions()
        {
            object text = "Hello World";
            List<string> list = new List<string>();

            Assert.That(text, Is.TypeOf<string>());
            Assert.That(list, Is.InstanceOf<IList>());
            Assert.That(_person, Is.TypeOf<People>());
            Assert.That(_person, Is.InstanceOf<People>());
            Assert.That(_person.Name, Is.InstanceOf<string>());
            Assert.That(_person.Age, Is.InstanceOf<int>());
        }

        [Test]
        public void NullAssertions()
        {
            string str = null;
            object obj = new object();
            Assert.That(str, Is.Null);
            Assert.That(obj, Is.Not.Null);
        }

        [Test]
        public void BooleanAssertions()
        {
            bool condition = true;
            bool anotherCondition = false;
            Assert.That(condition, Is.True);
            Assert.That(anotherCondition, Is.False);
            Assert.That(5 > 3, Is.True);
            Assert.That(3 > 5, Is.False);
        }

        [Test]
        public void PropertyAssertions()
        {
            Assert.That(_person, Has.Property("Name").EqualTo("John Doe"));
            Assert.That(_person, Has.Property("Age").GreaterThan(20));
            Assert.That(_person, Has.Property("Email").Contains("@"));
        }

        [Test]
        public void ExceptionAssertions()
        {
            TestDelegate codeThatThrows = () => throw new InvalidOperationException("Invalid operation occurred");
            Assert.That(codeThatThrows, Throws.TypeOf<InvalidOperationException>());
            Assert.That(codeThatThrows, Throws.Exception.Message.EqualTo("Invalid operation occurred"));
            TestDelegate codeThatDoesNotThrow = () => { var x = 5 + 5; };
            Assert.That(codeThatDoesNotThrow, Throws.Nothing);
        }

        [Test]
        public void MultipleAssertions()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_person.Name, Is.EqualTo("John Doe"));
                Assert.That(_person.Age, Is.GreaterThan(20));
                Assert.That(_person.Email, Does.Contain("@"));
            });
        }

        [Test]
        public void CustomMessageAssertions()
        {
            int value = 10;
            Assert.That(value, Is.GreaterThan(5), "Value should be greater than 5");
            Assert.That(value, Is.LessThan(20), "Value should be less than 20");
        }

        [Test]
        public void DateAssertions()
        {
            DateTime Now = DateTime.Now;
            DateTime future = Now.AddDays(1);
            DateTime past = Now.AddDays(-1);

            Assert.That(future, Is.GreaterThan(Now));
            Assert.That(past, Is.LessThan(Now));
            Assert.That(Now, Is.InRange(past, future));
            Assert.That(Now, Is.EqualTo(DateTime.Now).Within(1).Seconds);
        }
    }
}
