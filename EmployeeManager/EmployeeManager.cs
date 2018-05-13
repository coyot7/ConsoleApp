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
        private readonly string _fileName;
        private readonly EmployeeSerializer _serializer;
        public string FindEmployeeString { get; set; }

        public EmployeeManager(EmployeeSerializer serializer, string fileName)
        {
            _fileName = fileName;
            _serializer = serializer;
        }

        public List<Employee> Load()
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

        private List<Employee> FindList(Func<List<Employee>, List<Employee>> findEmployees)
        {
            var existing = Load();
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
