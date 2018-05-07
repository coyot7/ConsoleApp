using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeeManagers;

namespace ConsoleApp
{
    public class ReadWrite
    {
        public EmployeeManager Load(EmployeeManager emplManager)
        {
            string line;
            char znak = ',';
            StreamReader sr = new StreamReader("text.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] temp = line.Split(znak);

                string firstName = temp[0];
                string lastName = temp[1];
                int age = int.Parse(temp[2]);

                Employee emp = new Employee(firstName, lastName, age);
                emplManager.Add(emp);
            }
            sr.Close();

            return emplManager;
        }

        public void Save(Employee empl)
        {
            StreamWriter sw;
            sw = File.AppendText("text.txt");
            sw.WriteLine($"{empl.FirstName},{empl.LastName},{empl.Age}");
            sw.Close();
        }

        public void Delete(int indexLine)
        {
            var file = new List<string>(System.IO.File.ReadAllLines("text.txt"));
            file.RemoveAt(indexLine);
            File.WriteAllLines("text.txt", file.ToArray());
        }

        public void Modification(int indexLine, Employee empl)
        {
            string destinationFile = "text.txt";
            string tempFile = "temp.txt";

            string lineToWrite = empl.FirstName + "," + empl.LastName + "," + empl.Age;
            
            int line_number = 1;
            string line = null;
            using (StreamReader reader = new StreamReader(destinationFile))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line_number == indexLine)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                    line_number++;
                }
            }

            File.Delete("text.txt");
            File.Move("temp.txt", "text.txt");
        }
    }
}
