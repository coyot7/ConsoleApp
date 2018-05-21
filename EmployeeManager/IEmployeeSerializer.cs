using EmployeeManagers;

namespace EmployeeManager
{
    public interface IEmployeeSerializer
    {
        string Serialize(Employee employee);

        Employee Deserialize(string employeeSerialized);
    }
}