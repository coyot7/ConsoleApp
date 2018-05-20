using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagers;
using System.Collections.Generic;

namespace EmployeeManagerTests
{
    [TestClass]
    public class EmployeeManagerTests
    {

        public string FindEmployeeString { get; set; }
        private readonly IEmployeeProvider _employeeProvider;

        public EmployeeManagerTests()
        {
            EmployeeProviderTests employeeProviderTests = new EmployeeProviderTests();
            _employeeProvider = employeeProviderTests;
        }

        private void Modify(Action<List<Employee>> modifyEmployees)
        {
            var existing = _employeeProvider.Load();
            modifyEmployees(existing);
            _employeeProvider.Save(existing);
        }


        [TestMethod]
        public void Add()
        {
            Employee empl = new Employee("Test", "Test", 10);
            Modify(employees => employees.Add(empl));
            var existing = _employeeProvider.Load();
            Assert.AreEqual(empl, existing.Find(x => x.FirstName == "Test"));
        }

        [TestMethod]
        public void Change()
        {
            int index = 1;
            Employee empl = new Employee("TestCh", "TestCh", 10);

            Modify(employees => employees.RemoveAt(index));
            Modify(employess => employess.Insert(index, empl));

            var existing = _employeeProvider.Load();
            Assert.AreEqual(empl, existing.Find(x => x.FirstName == "TestCh"));
        }
    }
}