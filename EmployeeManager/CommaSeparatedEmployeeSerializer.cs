namespace EmployeeManager
{
    public class CommaSeparatedEmployeeSerializer : CharSeparatedEmployeeSerializer
    {
        protected override char Separator => ',';
    }
}
