using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeManagers
{
    public class EmployeeProvider
    {
        private readonly string _fileName;

        public EmployeeProvider(string fileName)
        {
            _fileName = fileName;
        }

        public List<Employee> Load()
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                string line;
                List<Employee> result = new List<Employee>();
                while ((line = reader.ReadLine()) != null)
                {
                    if (Deserialize(line) != null)
                    {
                        result.Add(Deserialize(line));
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }
        }

        public void Save(List<Employee> employees)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Employee employee in employees)
            {
                string line = Serialize(employee);
                builder.AppendLine(line);
            }

            File.WriteAllText(_fileName, builder.ToString());
        }

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
