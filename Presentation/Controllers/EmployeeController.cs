using Application.Dtos;
using Application.Services.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) =>
            _employeeService = employeeService;

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(EmployeeViewModel model)
        //{
           

        //    var viewModel = new EmployeeViewModel
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = model.Name,
                
        //    };

            
        //}

    }
}
