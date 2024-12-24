using PracticalTest.Models;

namespace PracticalTest.Repository.IRepository
{
    public interface IEmployeeRepo
    {
        Task<Employee> EditEmployeeAsync(Employee employee);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<IEnumerable<Employee>> GetEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int Id);
    }
}
