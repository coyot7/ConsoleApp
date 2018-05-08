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
        private List<Employee> listEmpl;
        public List<Employee> ListEmpl { get => listEmpl; private set => listEmpl = value; }


        public EmployeeManager()
        {
            listEmpl = new List<Employee>();
        }

        public void Add(Employee item)
        {
            listEmpl.Add(item);
        }

        public EmployeeManager SearchString(string value)
        {
            EmployeeManager findedString = new EmployeeManager();
            foreach (Employee elemnt in listEmpl)
            {
                if (elemnt.FirstName.Equals(value) || elemnt.LastName.Equals(value))
                {
                    findedString.Add(elemnt);
                }
            }

            return findedString;
        }

        public void Delete(int indexLine)
        {
            var file = new List<string>(System.IO.File.ReadAllLines("text.txt"));
            file.RemoveAt(indexLine);
            File.WriteAllLines("text.txt", file.ToArray());
        }
    }
}
