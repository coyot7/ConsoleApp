using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagers
{
    public class Employee 
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public Employee(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            Employee e = (Employee) obj;
            return e.Age == this.Age &&
                   e.FirstName == this.FirstName &&
                   e.LastName == this.LastName;
        }

        public override int GetHashCode()
        {
            return Age.GetHashCode() + FirstName.GetHashCode() + LastName.GetHashCode();
        }
    }
}
