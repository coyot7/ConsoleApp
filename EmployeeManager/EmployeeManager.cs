using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeeManagers;

namespace EmployeeManager
{
    public class EmployeeManager
    {
        private readonly IEmployeeProvider _employeeProvider;

        public EmployeeManager(IEmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
        }

        private void Modify(Action<List<Employee>> modifyEmployees)
        {
            var existing = _employeeProvider.Load();
            modifyEmployees(existing);
            _employeeProvider.Save(existing);
        }

        public void Add(Employee empl)
        {
            Modify(employees => employees.Add(empl));
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeProvider.Load();
        }

        public void Change(Employee empl, int index)
        {
            Modify(employees =>
            {
                employees.RemoveAt(index);
                employees.Insert(index, empl);
            });
        }

        public void Delete(int index)
        {
            Modify(employees => employees.RemoveAt(index));
        }

        public List<Employee> FindEmployee(string value)
        {
            var existing = _employeeProvider.Load();

            return existing.FindAll(
                e => e.FirstName == value ||
                     e.LastName == value);
        }
    }
}
