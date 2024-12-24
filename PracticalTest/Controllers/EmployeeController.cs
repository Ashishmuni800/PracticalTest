using Microsoft.AspNetCore.Mvc;

namespace PracticalTest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PracticalTest.Data;
    using PracticalTest.Models;
    using PracticalTest.Repository.IRepository;
    using System.Linq;

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employee;
        public EmployeeController(IEmployeeRepo employee)
        {
            _employee = employee;
        }

        // Display the employee form and data
        public async Task<IActionResult> Index()
        {
            var employees = await _employee.GetEmployeeAsync().ConfigureAwait(false);
            return View(employees);
        }

        // Handle employee form submission
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employee.AddEmployeeAsync(model).ConfigureAwait(false);
                // Redirect to the index to see the updated list
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int Id)
        {
            var employees = await _employee.GetEmployeeByIdAsync(Id).ConfigureAwait(false);
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employee.EditEmployeeAsync(model).ConfigureAwait(false);
                // Redirect to the index to see the updated list
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }

}
