using Microsoft.EntityFrameworkCore;

namespace PracticalTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; } // true for Male, false for Female
        public string Department { get; set; }
        public string Designation { get; set; }
        public float BasicSalary { get; set; }
    }

}
