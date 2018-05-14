
namespace EmployeeManager
{
    public class EmployeeSerializer
    {
        public string Serialize(Employee employee)
        {
            return $"{employee.FirstName},{employee.LastName},{employee.Age}";
        }

        public Employee Deserialize(string employeeSerialized)
        {
            string[] temp = employeeSerialized.Split(',');

            string firstName = temp[0];
            string lastName = temp[1];
            int age = int.Parse(temp[2]);

            return new Employee(firstName, lastName, age);
        }
    }
}
