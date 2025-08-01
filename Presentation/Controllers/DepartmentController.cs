﻿using Application.Dtos;
using Application.Services.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoMapping;
using Presentation.Models;

namespace Presentation.Controllers;
[Authorize]
public class DepartmentController : BaseController
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();

        var viewModel = departments.ToViewModel();

        return View(viewModel);
    }

    public ActionResult Details(int id)
    {
        return View();
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateDepartmentViewModel model)
    {
        if(!ModelState.IsValid)
        {
            SetFlashMessage("Please fill in all required fields correctly.", "error");
            return View(model);
        }

        var viewModel = new CreateDepartmentDto
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description
        };

        var result = await _departmentService.CreateDepartmentAsync(viewModel);

        if (result == null)
        {
            SetFlashMessage("An error occurred while creating the department. Please try again.", "error");
            return View(model);
        }
        
        SetFlashMessage("Department created successfully.", "success");

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Edit(Guid Id)
    {
        if (!ModelState.IsValid)
        {
            SetFlashMessage("Please fill in all required fields correctly.", "error");
            return View();
        }

        var result = await _departmentService.GetDepartmentByIdAsync(Id);
        if (result == null)
        {
            return View();
        }
        var viewModel = result.ToViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateDepartmentViewModel model)
    {

        if (!ModelState.IsValid)
        {
            SetFlashMessage("Please fill in all required fields correctly.", "error");
            return View(model);
        }

        var viewModel = new UpdateDepartmentDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description
        };

        var result = await _departmentService.UpdateDepartmentAsync(viewModel);


        SetFlashMessage("Department updated successfully.", "success");

        return RedirectToAction(nameof(Index));
       
    }

    public ActionResult Delete(int id)
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
         await _departmentService.DeleteDepartmentAsync(id);

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
            var result = await _departmentService.GetDepartmentByIdAsync(id);
        if (result == null)
        {
            return View();
        }
        
        return View(result);   
        }



    }




