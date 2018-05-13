using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "text.txt";

            EmployeeSerializer employeeSerializer = new EmployeeSerializer();
            EmployeeManager emplManager = new EmployeeManager(employeeSerializer, fileName);

            ConsoleKeyInfo cki;
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Wyswietl plik");
                Console.WriteLine("2. Dodaj rekord");
                Console.WriteLine("3. Zmien rekord");
                Console.WriteLine("4. Usun rekord");
                Console.WriteLine("5. Szukaj rekord");
                Console.WriteLine("");
                Console.WriteLine("Q Wyjscie");

                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            Logger log = new Logger();
                            log.Display();
                            Console.WriteLine("");
                            Console.WriteLine("Wcisnij dowolny klawisz: ");
                            Console.ReadLine();
                        }
                        break;

                    case ConsoleKey.D2:
                        {
                            Console.Clear();

                            Console.WriteLine("Podaj imie: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko: ");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Podaj wiek: ");
                            int age = int.Parse(Console.ReadLine());

                            Employee empl = new Employee(firstName, lastName, age);
                            emplManager.Add(empl);
                        }
                        break;

                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj index rekordu do zmiany: ");
                            int index = int.Parse(Console.ReadLine());

                            Console.WriteLine("Podaj imie: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko: ");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Podaj wiek: ");
                            int age = int.Parse(Console.ReadLine());
                            
                            Employee employ = new Employee(firstName, lastName, age);
                            emplManager.Change(employ, index - 1);
                        }
                        break;

                    case ConsoleKey.D4:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj index rekordu do usuniecia: ");
                            int index = int.Parse(Console.ReadLine());

                            emplManager.Delete(index - 1);
                        }
                        break;

                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            Console.WriteLine("Wprowadz szukany ciag: ");
                            string searchString = Console.ReadLine();
                            List<Employee> finded = emplManager.FindEmployee(searchString);

                            Logger log = new Logger();
                            log.DisplayList(finded);
                        }
                        break;


                    default:
                        break;
                }

            } while (cki.Key != ConsoleKey.Q && exit != true);

            Console.Clear();
        }
    }
}
