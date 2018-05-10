﻿using System;
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
                    result.Add(_serializer.Deserialize(line));
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

        //private void Modify(Action<List<Employee>> modifyEmployees)
        //{
        //    var existing = Load();
        //    modifyEmployees(existing);
        //    Save(existing);
        //}

        public void Add(Employee empl)
        {
            var existing = Load();
            existing.Add(empl);
            Save(existing);
            //Modify(employees => employees.Add(empl));
        }

        
    }
}
