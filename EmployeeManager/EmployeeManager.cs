using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeManagers
{
    public class EmployeeManager
    {
        
        public string FindEmployeeString { get; set; }
        private readonly EmployeeProvider _employeeProvider;

        public EmployeeManager(EmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
        }


        private void Modify(Action<List<Employee>> modifyEmployees)
        {
            var existing = _employeeProvider.Load();
            modifyEmployees(existing);
            _employeeProvider.Save(existing);
        }

        private List<Employee> FindList(Func<List<Employee>, List<Employee>> findEmployees)
        {
            var existing = _employeeProvider.Load();
            List<Employee> temp = findEmployees(existing);
            return temp;
        }

        public void Add(Employee empl)
        {
            Modify(employees => employees.Add(empl));
        }

        public void Change(Employee empl, int index)
        {
            Modify(employees => employees.RemoveAt(index));
            Modify(employess => employess.Insert(index, empl));
        }

        public void Delete(int index)
        {
            Modify(employees => employees.RemoveAt(index));
        }

        public List<Employee> FindEmployee(string value)
        {
            FindEmployeeString = value;
            List<Employee> findedList = FindList(empl => empl.FindAll(Find));

            return findedList;
        }

        private bool Find(Employee value)
        {
            if (value.FirstName == FindEmployeeString || value.LastName == FindEmployeeString)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
