using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeeManagers;

namespace ConsoleApp
{
    public class Logger
    {
        public void Display()
        {
            EmployeeSerializer employeeSerializer = new EmployeeSerializer();
            EmployeeManager employeeManager = new EmployeeManager(employeeSerializer, "text.txt");
            List<Employee> employees = employeeManager.Load();

            int i = 0;
            foreach (Employee element in employees)
            {
                i++;
                Console.WriteLine($"{i}. {element.FirstName}, {element.LastName}, {element.Age}");
            }
        }
    }
}
