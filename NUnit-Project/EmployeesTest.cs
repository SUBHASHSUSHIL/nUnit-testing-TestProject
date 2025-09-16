using NUnit.Framework;
using nUnit_testing_TestProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project
{
    [TestFixture]
    public class EmployeesTest
    {
        private Employee _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Employee();
        }

        [Test]
        public void AddEmployee()
        {
            //Arange
            _employee = new Employee { Id = 1, Name = "Hello", Email = "hello@gmail.com" };

            //Act
            _employee.Employees.Add(_employee);

            //Assert
            Assert.That(_employee.Id, Is.EqualTo(1));
            Assert.That(_employee.Name, Is.EqualTo("Hello"));

        }
    }
}
