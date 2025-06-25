using Application.Dtos;

namespace Application.Services.Employee
{
     public interface IEmployeeService
    {
        Task<EmployeesDto> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto dto);
        Task<EmployeeDto> DeleteEmployeeAsync(Guid Id);

    }
}
