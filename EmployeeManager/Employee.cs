using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagers
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName { get => firstName; private set => firstName = value; }
        public string LastName { get => lastName; private set => lastName = value; }
        public int Age { get => age; private set => age = value; }

        public Employee()
        { }

        public Employee(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }
}
