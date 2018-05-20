using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagers;
using System.Collections.Generic;

namespace EmployeeManagerTests
{
    //[TestClass]
    public class EmployeeProviderTests : IEmployeeProvider
    {
        private List<Employee> _listEmpl;

        public EmployeeProviderTests()
        {
            _listEmpl = new List<Employee>();
            Employee employee = new Employee("Agnieszka", "Kowalska", 33);
            Employee employee2 = new Employee("Jan", "Kowalski", 33);

            _listEmpl.Add(employee);
            _listEmpl.Add(employee2);
        }

        public Employee Deserialize(string employeeSerialized)
        {
            throw new NotImplementedException();
        }

        //[TestMethod]
        public List<Employee> Load()
        {
            return _listEmpl;
        }

        public void Save(List<Employee> employees)
        {
            _listEmpl = employees;
        }

        public string Serialize(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
