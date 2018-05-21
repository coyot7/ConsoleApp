using System;
using System.Collections.Generic;
using EmployeeManager;
using EmployeeManagers;

namespace EmployeeManagerTests.Helpers
{
    public class EmployeeProviderMock : IEmployeeProvider
    {
        private readonly List<Employee> _toLoad;

        private readonly Action<List<Employee>> _saveCallback;

        public EmployeeProviderMock(
            List<Employee> toLoad,
            Action<List<Employee>> saveCallback)
        {
            _toLoad = toLoad;
            _saveCallback = saveCallback;
        }

        public List<Employee> Load()
        {
            return _toLoad;
        }

        public void Save(List<Employee> employees)
        {
            _saveCallback(employees);
        }
    }
}
