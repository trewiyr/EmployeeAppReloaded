using Application.Dtos;
using Data.Model;

namespace Application.ContractMapping;
public static class Mapper
{
    public static DepartmentDto ToDto(this Department department)
    {
        if (department == null) return null!;

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description
        };
    }

    public static Department ToModel(this CreateDepartmentDto createDepartmentDto)
    {
        if (createDepartmentDto == null) return null!;
        return new Department
        {
            Id = Guid.NewGuid(),
            Name = createDepartmentDto.Name,
            Description = createDepartmentDto.Description
        };
    }


    public static Department ToModel(this UpdateDepartmentDto updateDepartmentDto)
    {
        if (updateDepartmentDto == null) return null!;
        return new Department
        {
            Id = Guid.NewGuid(),
            Name = updateDepartmentDto.Name,
            Description = updateDepartmentDto.Description
        };
    }

    public static EmployeeDto ToDto(this Employee employee)
    {
        if (employee == null) return null!;

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email= employee.Email,
            HireDate = employee.HireDate,
            Salary = employee.Salary,
            Address = employee.Address
        };
    }

    public static Employee ToModel(this CreateEmployeeDto createEmployeeDto)
    {
        if (createEmployeeDto == null) return null!;
        return new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = createEmployeeDto.FirstName,
            LastName = createEmployeeDto.LastName,
            Email = createEmployeeDto.Email,
            HireDate = createEmployeeDto.HireDate,
            Salary = createEmployeeDto.Salary,
            DepartmentId = createEmployeeDto.DepartmentId,
            Address = createEmployeeDto.Address
        };
    }
    public static DepartmentsDto DepartmentsDto(this List<Department> departments)
    {
        if (departments == null || !departments.Any()) return null!;
        return new DepartmentsDto
        {
            Departments = departments.Select(d => d.ToDto()).ToList()
        };
    }
    public static EmployeesDto EmployeesDto(this List<Employee> employees)
    {
        if (employees == null || !employees.Any()) return null!;
        return new EmployeesDto
        {
            Employees = employees.Select(d => d.ToDto()).ToList()
        };
    }
    public static Employee ToModel(this UpdateEmployeeDto updateEmployeeDto)
    {
        if (updateEmployeeDto == null) return null!;
        return new Employee
        {
            FirstName = updateEmployeeDto.FirstName,
            LastName = updateEmployeeDto.LastName,
            Email = updateEmployeeDto.Email,
            HireDate = updateEmployeeDto.HireDate,
            Salary = updateEmployeeDto.Salary,
            DepartmentId = updateEmployeeDto.DepartmentId,
            Address = updateEmployeeDto.Address
        };
    }
    public static AddressDto ToDto(this Address address)
    {
        if (address == null) return null!;

        return new AddressDto
        {
            Id = address.Id,
            StreetNo = address.StreetNo,
            City = address.City,
            StreetName = address.StreetName,
            //State = address.State
        };
    }
    public static Address ToModel(this CreateAddressDto createAddressDto)
    {
        if (createAddressDto == null) return null!;
        return new Address
        {
            Id = createAddressDto.Id,
            StreetNo = createAddressDto.StreetNo,
            City = createAddressDto.City,
            StreetName = createAddressDto.StreetName,
            Employee = createAddressDto.Employee,
            //State = createAddressDto.State
        };
    }
    public static Address ToModel(this UpdateAddressDto updateAddressDto)
    {
        if (updateAddressDto == null) return null!;
        return new Address
        {
            Id = updateAddressDto.Id,
            StreetNo = updateAddressDto.StreetNo,
            City = updateAddressDto.City,
            StreetName = updateAddressDto.StreetName,
            Employee = updateAddressDto.Employee,
            //State = updateAddressDto.State
        };
    }
}
