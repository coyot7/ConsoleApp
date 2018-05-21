namespace EmployeeManager
{
    public class SemicolonSeparatedEmployeeSerializer : CharSeparatedEmployeeSerializer
    {
        protected override char Separator => ';';
    }
}
