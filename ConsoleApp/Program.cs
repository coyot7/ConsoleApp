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
            emplManager = rw.load(emplManager);

            //emplManager.wypelnij();
            //emplManager.show();

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
                            emplManager = rw.load(emplManager);
                            emplManager.show();
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
                            empl.setFirstName(Console.ReadLine());
                            Console.WriteLine("Podaj nazwisko: ");
                            empl.setLastName(Console.ReadLine());
                            Console.WriteLine("Podaj wiek: ");
                            empl.setAge(int.Parse(Console.ReadLine()));

                            // emplManager.add(empl);
                            rw.save(empl);
                           
                        }
                        break;

                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj index rekordu do zmiany: ");
                            int index = int.Parse(Console.ReadLine());

                            Employee empl = new Employee();

                            Console.WriteLine("Podaj imie: ");
                            empl.setFirstName(Console.ReadLine());
                            Console.WriteLine("Podaj nazwisko: ");
                            empl.setLastName(Console.ReadLine());
                            Console.WriteLine("Podaj wiek: ");
                            empl.setAge(int.Parse(Console.ReadLine()));

                            //emplManager.modification(empl, index);
                            rw.modification(index, empl);
                        }
                        break;

                    case ConsoleKey.D4:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj index rekordu do usuniecia: ");
                            int index = int.Parse(Console.ReadLine());

                            rw.delete(index - 1);
                            //emplManager.remove(index);
                        }
                        break;

                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            emplManager = new EmployeeManager();
                            emplManager = rw.load(emplManager);
                            Console.WriteLine("Wprowadz szukany ciag: ");
                            string searchString = Console.ReadLine();

                            bool[] tablica = emplManager.searchString(searchString);
                            for (int i = 0; i < tablica.Length; i++)
                            {
                                if (tablica[i] == true)
                                {
                                    emplManager.showOne(i);
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
            //Console.ReadLine();
        }
    }
}
