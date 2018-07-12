namespace Employees.App.Models
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {EmployeeId} - {FirstName} {LastName} - ${Salary:f2}";
        }
    }
}