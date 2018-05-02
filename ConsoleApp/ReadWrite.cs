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
        public EmployeeManager load(EmployeeManager emplManager)
        {
            string line;
            char znak = ',';
            StreamReader sr = new StreamReader("text.txt");
            while ((line = sr.ReadLine()) != null)
            {
                Employee emp = new Employee();
                string[] temp = line.Split(znak);

                emp.setFirstName(temp[0]);
                emp.setLastName(temp[1]);
                emp.setAge(int.Parse(temp[2]));
                emplManager.add(emp);
            }
            sr.Close();

            return emplManager;
        }

        public void save(Employee empl)
        {
            StreamWriter sw;
            sw = File.AppendText("text.txt");
            sw.WriteLine("{0},{1},{2}", empl.getFirstName(), empl.getLastName(), empl.getAge());
            sw.Close();
        }

        public void delete(int indexLine)
        {
            var file = new List<string>(System.IO.File.ReadAllLines("text.txt"));
            file.RemoveAt(indexLine);
            File.WriteAllLines("text.txt", file.ToArray());
        }

        public void modification(int indexLine, Employee empl)
        {
            //string sourceFile = "text.txt";
            string destinationFile = "text.txt";
            string tempFile = "temp.txt";

            // Read the appropriate line from the file.
            string lineToWrite = empl.getFirstName() + "," + empl.getLastName() + "," + empl.getAge();
            //using (StreamReader reader = new StreamReader(sourceFile))
            //{
            //    for (int i = 1; i <= indexLine; ++i)
            //        lineToWrite = reader.ReadLine();
            //}

            //if (lineToWrite == null)
            //    throw new InvalidDataException("Line does not exist in " + sourceFile);

            // Read from the target file and write to a new file.
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
