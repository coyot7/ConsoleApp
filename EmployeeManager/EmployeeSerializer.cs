using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeManagers
{
    public class EmployeeSerializer
    {
        public string Serialize(Employee employee)
        {
            return $"{employee.FirstName},{employee.LastName},{employee.Age}";
        }

        public Employee Deserialize(string employeeSerialized)
        {
            string[] temp = employeeSerialized.Split(',');

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
