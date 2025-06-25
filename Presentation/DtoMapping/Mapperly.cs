using Application.Dtos;
using Data.Model;
using Presentation.Models;

namespace Presentation.DtoMapping;

public static class Mapperly
{
    // DepartmentViewModel <-> DepartmentDto
    public static DepartmentViewModel ToViewModel(this DepartmentDto dto)
    {
        return new DepartmentViewModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description
        };
    }

    public static DepartmentDto ToDto(this DepartmentViewModel vm)
    {
        return new DepartmentDto()
        {
            Id = vm.Id,
            Name = vm.Name,
            Description = vm.Description,
            Employees = []
        };
    }

    // DepartmentsViewModel <-> DepartmentsDto
    public static DepartmentsViewModel ToViewModel(this DepartmentsDto dto)
    {
        return new DepartmentsViewModel()
        {
            Departments = dto?.Departments?.Select(d => d.ToViewModel()).ToList() ?? new List<DepartmentViewModel>()
        };
    }

    public static DepartmentsDto ToDto(this DepartmentsViewModel vm)
    {
        return new DepartmentsDto()
        {
            Departments = vm?.Departments?.Select(d => d.ToDto()).ToList() ?? new List<DepartmentDto>()
        };
    }

    public static EmployeeViewModel ToViewModel(this EmployeeDto dto)
    {
        return new EmployeeViewModel()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            HireDate = dto.HireDate,
            Salary = dto.Salary,
            DepartmentId = dto.DepartmentId,
            Address = dto.Address,
};
    }

    public static AddressViewModel ToViewModel(this AddressDto dto)
    {
        return new AddressViewModel()
        {
            Id = dto.Id,
            StreetNo = dto.StreetNo,
            City = dto.City,
            StreetName = dto.StreetName,
            //State = dto.State
        };
    }

}
