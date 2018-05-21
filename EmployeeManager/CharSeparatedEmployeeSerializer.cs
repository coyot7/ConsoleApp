using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagers;

namespace EmployeeManager
{
    public abstract class CharSeparatedEmployeeSerializer : IEmployeeSerializer
    {
        protected abstract char Separator { get; }

        public string Serialize(Employee employee)
        {
            return $"{employee.FirstName}{Separator}{employee.LastName}{Separator}{employee.Age}";
        }

        public Employee Deserialize(string employeeSerialized)
        {
            string[] temp = employeeSerialized.Split(Separator);

            try
            {
                string firstName = temp[0];
                string lastName = temp[1];
                int age = int.Parse(temp[2]);

                return new Employee(firstName, lastName, age);
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}
