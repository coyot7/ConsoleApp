using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagers;

namespace EmployeeManager
{
    public interface IEmployeeProvider
    {
        List<Employee> Load();

        void Save(List<Employee> employees);
    }
}
