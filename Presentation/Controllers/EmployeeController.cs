using Application.Dtos;
using Application.Services.Department;
using Application.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Presentation.DtoMapping;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {

        private readonly IEmployeeService _employeeService;

        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();

            return View(employees);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var departmentsToDisplay = departments.Departments.Select(c => new { c.Id, Name = c.Name }).ToList();
            ViewBag.Departments = departmentsToDisplay;
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var viewModel = new CreateEmployeeDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HireDate = model.HireDate,
                Email = model.Email,
                DepartmentId = model.DepartmentId,
                Salary = model.Salary,
                
            };


            var result = await _employeeService.CreateEmployeeAsync(viewModel);
            if (result == null)
            {
                return View(model);
            }


            return RedirectToAction(nameof(Index)); ;
        }


        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var departmentsToDisplay = departments.Departments.Select(c => new { c.Id, Name = c.Name }).ToList();
            ViewBag.Departments = departmentsToDisplay;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateEmployeeViewModel model)
        {
            var employee = new UpdateEmployeeDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HireDate = model.HireDate,
                Email = model.Email,
                DepartmentId = model.DepartmentId,
                Salary = model.Salary
            };

            var result = await _employeeService.UpdateEmployeeAsync(employee);

            if (result == null)
            {
                return View(model);
            }


            return RedirectToAction(nameof(Index)); 

        }
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!ModelState.IsValid)
            {
                SetFlashMessage("Please fill in all required fields correctly.", "error");
                return View();
            }

            var result = await _employeeService.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return View();
            }
            var viewModel = result.ToViewModel();
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);

            try
            {
                SetFlashMessage("Deleted Succesfully!", "Success");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            if (result == null)
            {
                return View();
            }

            return View(result);
        }
        public ActionResult Details(Guid id)
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

       

    }
}

