using System.Collections.Generic;
using System.Text;
using System.IO;
using EmployeeManagers;

namespace EmployeeManager
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeSerializer _employeeSerializer;

        private readonly string _fileName;

        public EmployeeProvider(
            IEmployeeSerializer employeeSerializer,
            string fileName)
        {
            _employeeSerializer = employeeSerializer;
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
                    if (_employeeSerializer.Deserialize(line) != null)
                    {
                        result.Add(_employeeSerializer.Deserialize(line));
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
                string line = _employeeSerializer.Serialize(employee);
                builder.AppendLine(line);
            }

            File.WriteAllText(_fileName, builder.ToString());
        }
    }
}
