using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagers
{
    public class EmployeeManager
    {
        private
            //Employee empl = new Employee("Staszek", "Bizon", 33);
        List<Employee> listEmpl;// = new List<Employee>();

        public EmployeeManager()
        {
            listEmpl = new List<Employee>();
        }

        public void show()
        {
            //Console.WriteLine("{0}, {1}, {2}", empl.getFirstName(), empl.getLastName(), empl.getAge());
            int i = 0;
            foreach (Employee element in listEmpl)
            {
                i++;
                Console.WriteLine("{0}. {1}, {2}, {3}", i, element.getFirstName(), element.getLastName(), element.getAge());
            }
        }

        public void showOne(int index)
        {
            Console.WriteLine("{0}. {1}, {2}, {3}", index + 1, listEmpl.ElementAt(index).getFirstName(), listEmpl.ElementAt(index).getLastName(), listEmpl.ElementAt(index).getAge());
        }

        public void add(Employee item)
        {
            listEmpl.Add(item);
        }

        public void modification(Employee item, int index)
        {
            listEmpl.RemoveAt(index - 1);
            listEmpl.Insert(index - 1, item);
        }

        public void remove(int index)
        {
            listEmpl.RemoveAt(index - 1);
        }

        public int getCountIndex()
        {
            return listEmpl.Count;
        }

        public bool[] searchString(string value)
        {
            bool[] tablica = new bool[listEmpl.Count];
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = false;
            }

            int j = 0;
            foreach (Employee elemnt in listEmpl)
            {
                if (elemnt.getFirstName().Equals(value) || elemnt.getLastName().Equals(value))
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
