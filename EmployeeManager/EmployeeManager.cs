using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagers
{
    public class EmployeeManager
    {
        private List<Employee> listEmpl;

        public EmployeeManager()
        {
            listEmpl = new List<Employee>();
        }

        public void Show()
        {
            int i = 0;
            foreach (Employee element in listEmpl)
            {
                i++;
                Console.WriteLine($"{i}. {element.FirstName}, {element.LastName}, {element.Age}");
            }
        }

        public void ShowOne(int index)
        {
            Console.WriteLine($"{index + 1}. {listEmpl.ElementAt(index).FirstName}, {listEmpl.ElementAt(index).LastName}, {listEmpl.ElementAt(index).Age}");
        }

        public void Add(Employee item)
        {
            listEmpl.Add(item);
        }

        public bool[] SearchString(string value)
        {
            bool[] tablica = new bool[listEmpl.Count];
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = false;
            }

            int j = 0;
            foreach (Employee elemnt in listEmpl)
            {
                if (elemnt.FirstName.Equals(value) || elemnt.LastName.Equals(value))
                {
                    tablica[j] = true;
                }
                else
                {
                    tablica[j] = false;
                }
                j++;
            }

            return tablica;
        }
    }
}
