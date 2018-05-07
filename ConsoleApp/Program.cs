﻿using System;
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

            EmployeeManager emplManager = new EmployeeManager();
            
            //2do do wywalenia ta linia nizej jak przeniesiesz ReadWrite
            ReadWrite rw = new ReadWrite();

            EmployeeSerializer es = new EmployeeSerializer();
            es.Load(ref emplManager, fileName);

            //2do do wywalenia ta linia nizej jak przeniesiesz ReadWrite
            //emplManager = rw.Load(emplManager);


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

                            //2do do wywalenia ta linia nizej jak przeniesiesz ReadWrite
                            //emplManager = rw.Load(emplManager);
                            es.Load(ref emplManager, fileName);
                            emplManager.Show();
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
                            //2do do wywalenia ta linia nizej jak przeniesiesz ReadWrite
                            //rw.Save(empl);
                            es.Save(empl, fileName);
                           
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
                            Employee empl = new Employee(firstName, lastName, age);

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
                            //2do do wywalenia ta linia nizej jak przeniesiesz ReadWrite
                            //emplManager = rw.Load(emplManager);
                            es.Load(ref emplManager, fileName);
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
