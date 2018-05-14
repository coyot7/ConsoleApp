using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeManager
{
    public class EmployeeManager
    {
        private readonly string _fileName;
        private readonly EmployeeSerializer _serializer;

        public EmployeeManager(EmployeeSerializer serializer, string fileName)
        {
            _fileName = fileName;
            _serializer = serializer;
        }

        private List<Employee> Load()
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                string line;
                List<Employee> result = new List<Employee>();
                while ((line = reader.ReadLine()) != null)
                {
                    if (_serializer.Deserialize(line) != null)
                    {
                        result.Add(_serializer.Deserialize(line));
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }
        }

        private void Save(List<Employee> employees)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Employee employee in employees)
            {
                string line = _serializer.Serialize(employee);
                builder.AppendLine(line);
            }

            File.WriteAllText(_fileName, builder.ToString());
        }

        private void Modify(Action<List<Employee>> modifyEmployees)
        {
            var existing = Load();
            modifyEmployees(existing);
            Save(existing);
        }

        public void Add(Employee empl)
        {
            Modify(employees => employees.Add(empl));
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

        public IEnumerable<Employee> FindEmployees(string firstOrLastName)
        {
            var employees = Load();
            return employees.Where(
                e => e.FirstName == firstOrLastName ||
                     e.LastName == firstOrLastName);
        }

        public IEnumerable<Employee> GetAll()
        {
            return Load();
        }
    }
}
