using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeeManager;

namespace ConsoleApp
{
    public class Logger
    {
        public void Display()
        {
            EmployeeSerializer employeeSerializer = new EmployeeSerializer();
            var employeeManager = new EmployeeManager.EmployeeManager(employeeSerializer, "text.txt");
            var employees = employeeManager.GetAll().ToList();

            DisplayList(employees);
        }

        public void DisplayList(List<Employee> list)
        {
            int i = 1;
            foreach (Employee element in list)
            {
                Console.WriteLine($"{i}. {element.FirstName}, {element.LastName}, {element.Age}");
                i++;
            }
        }
    }
}
