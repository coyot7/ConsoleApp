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
            EmployeeManager emplManager = new EmployeeManager();
            ReadWrite rw = new ReadWrite();
            emplManager = rw.Load(emplManager);

            
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
                            emplManager = new EmployeeManager();
                            emplManager = rw.Load(emplManager);
                            emplManager.Show();
                            Console.WriteLine("");
                            Console.WriteLine("Wcisnij dowolny klawisz: ");
                            Console.ReadLine();
                        }
                        break;

                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            Employee empl = new Employee();

                            Console.WriteLine("Podaj imie: ");
                            empl.FirstName = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko: ");
                            empl.LastName = Console.ReadLine();
                            Console.WriteLine("Podaj wiek: ");
                            empl.Age = int.Parse(Console.ReadLine());

                            rw.Save(empl);
                           
                        }
                        break;

                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj index rekordu do zmiany: ");
                            int index = int.Parse(Console.ReadLine());

                            Employee empl = new Employee();

                            Console.WriteLine("Podaj imie: ");
                            empl.FirstName = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko: ");
                            empl.LastName = Console.ReadLine();
                            Console.WriteLine("Podaj wiek: ");
                            empl.Age = int.Parse(Console.ReadLine());
                            rw.Modification(index, empl);
                        }
                        break;

                    case ConsoleKey.D4:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj index rekordu do usuniecia: ");
                            int index = int.Parse(Console.ReadLine());

                            rw.Delete(index - 1);
                        }
                        break;

                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            emplManager = new EmployeeManager();
                            emplManager = rw.Load(emplManager);
                            Console.WriteLine("Wprowadz szukany ciag: ");
                            string searchString = Console.ReadLine();

                            bool[] tablica = emplManager.SearchString(searchString);
                            for (int i = 0; i < tablica.Length; i++)
                            {
                                if (tablica[i] == true)
                                {
                                    emplManager.ShowOne(i);
                                }
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Wcisnij dowolny klawisz: ");
                            Console.ReadLine();
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
