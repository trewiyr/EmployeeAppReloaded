using Application.ContractMapping;
using Application.Dtos;
using Data.Context;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services.Department;

public class DepartmentService : IDepartmentService
{
    private readonly EmployeeAppDbContext _context;

    public DepartmentService(EmployeeAppDbContext context)
    {
        _context = context;
    }

    public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        var data = new CreateDepartmentDto
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description
        };

        var department = data.ToModel();

        try
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return department.ToDto();
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error occurred while creating the department.", ex);
            return new DepartmentDto();
        }
    }

    public async Task<DepartmentDto> DeleteDepartmentAsync(Guid departmentId)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
        _context.Departments.Remove(department!);
        await _context.SaveChangesAsync();
        return department?.ToDto()!;
    }

    public async Task<DepartmentsDto> GetAllDepartmentsAsync()
    {
        var departments = await _context.Departments.ToListAsync();

        return departments.DepartmentsDto();
    }

    public async Task<DepartmentDto> GetDepartmentByIdAsync(Guid id)
    {
        var department = await _context.Departments
        .AsNoTracking()
        .FirstOrDefaultAsync(d => d.Id == id);

        return department?.ToDto()!;
    }

    public async Task<DepartmentDto> UpdateDepartmentAsync(UpdateDepartmentDto dto)
    {
        var department =  _context.Departments.FirstOrDefault(d=>d.Id == dto.Id);
        var data = new UpdateDepartmentDto
        {
            Name = dto.Name,
            Description = dto.Description
        };

         department = data.ToModel();

        try
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return department.ToDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the department.", ex);
            return new DepartmentDto();
        }
    }
}
