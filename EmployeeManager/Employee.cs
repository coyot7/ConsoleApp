using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagers
{
    public class Employee
    {
        private
            string firstName;
            string lastName;
            int age;

        public Employee()
        { }

        public Employee(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            }

        public string getFirstName() { return firstName; }
        public void setFirstName(string value) { firstName = value; }
        public string getLastName() { return lastName; }
        public void setLastName(string value) { lastName = value; }
        public int getAge() { return age; }
        public void setAge(int value) { age = value; }
    }
}
