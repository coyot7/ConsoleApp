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
        public EmployeeSerializer()
        { }

        public void Load(ref EmployeeManager emplManager, string fileName)
        {
            string line;
            char znak = ',';
            StreamReader sr = new StreamReader(fileName);
            while ((line = sr.ReadLine()) != null)
            {
                string[] temp = line.Split(znak);

                string firstName = temp[0];
                string lastName = temp[1];
                int age = int.Parse(temp[2]);

                Employee emp = new Employee(firstName, lastName, age);
                emplManager.Add(emp);
            }
            sr.Close();
        }

        public void Save(Employee empl, string fileName)
        {
            StreamWriter sw;
            sw = File.AppendText(fileName);
            sw.WriteLine($"{empl.FirstName},{empl.LastName},{empl.Age}");
            sw.Close();
        }
    }
}
