using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagers;
using System.Collections.Generic;
using EmployeeManager;
using EmployeeManagerTests.Helpers;

namespace EmployeeManagerTests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        [TestMethod]
        public void NewlyAddedEmploeeIsSavedToProvider()
        {
            // arrange
            var newEmployee = new Employee("Krzysiek", "Kowalski", 30);
            List<Employee> savedList = null;
            var providerMock = new EmployeeProviderMock(
                toLoad: new List<Employee>(),
                saveCallback: list =>
                {
                    savedList = list;
                });
            var manager = new EmployeeManager.EmployeeManager(providerMock);

            // act
            manager.Add(newEmployee);

            // assert
            Assert.AreEqual(savedList[0], newEmployee);
        }

        // TODO: zaimplementować więcej testów na reszte metod
    }
}