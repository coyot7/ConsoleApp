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
        private EmployeeManager employeeManager;
        public EmployeeManager EmployeeManager { get => employeeManager; private set => employeeManager = value; }

        public Logger()
        { }

        public Logger(EmployeeManager employeeManager)
        {
            EmployeeManager = employeeManager;
        }


        public void Display()
        {
            int i = 0;
            foreach (Employee element in EmployeeManager.ListEmpl)
            {
                i++;
                Console.WriteLine($"{i}. {element.FirstName}, {element.LastName}, {element.Age}");
            }
        }
    }
}
