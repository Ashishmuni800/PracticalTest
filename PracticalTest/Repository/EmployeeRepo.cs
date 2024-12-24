using Microsoft.EntityFrameworkCore;
using PracticalTest.Data;
using PracticalTest.Models;
using PracticalTest.Repository.IRepository;

namespace PracticalTest.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _employee;
        public EmployeeRepo(ApplicationDbContext context)
        {
            _employee = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // Calculate the allowances and deductions
            var dearnessAllowance = employee.BasicSalary * 0.40f;
            var conveyanceAllowance = Math.Min(dearnessAllowance * 0.10f, 250);
            var houseRentAllowance = Math.Max(employee.BasicSalary * 0.25f, 1500);

            var grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;

            // Calculate PT based on GrossSalary
            int pt = grossSalary <= 3000 ? 100 : grossSalary <= 6000 ? 150 : 200;

            var totalSalary = grossSalary - pt;

            // Save the employee details to the database
            await _employee.Employee.AddAsync(employee);
            await _employee.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> EditEmployeeAsync(Employee employee)
        {
            // Calculate the allowances and deductions
            var dearnessAllowance = employee.BasicSalary * 0.40f;
            var conveyanceAllowance = Math.Min(dearnessAllowance * 0.10f, 250);
            var houseRentAllowance = Math.Max(employee.BasicSalary * 0.25f, 1500);

            var grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;

            // Calculate PT based on GrossSalary
            int pt = grossSalary <= 3000 ? 100 : grossSalary <= 6000 ? 150 : 200;

            var totalSalary = grossSalary - pt;

            // update the employee details to the database
             _employee.Employee.Update(employee);
            await _employee.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            var employees = await _employee.Employee.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            return  await _employee.Employee.Where(ep => ep.Id == Id).SingleOrDefaultAsync();
        }
    }
}
