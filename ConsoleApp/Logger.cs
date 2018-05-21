using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeeManager;
using EmployeeManagers;

namespace ConsoleApp
{
    public class Logger
    {
        public void DisplayList(List<Employee> list)
        {
            int i = 1;
            for (var index = 0; index < list.Count; index++)
            {
                Employee element = list[index];
                Console.WriteLine($"{i}. {element.FirstName}, {element.LastName}, {element.Age}");
                i++;
            }
        }
    }
}
