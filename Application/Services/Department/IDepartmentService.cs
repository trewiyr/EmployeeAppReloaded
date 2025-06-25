using Application.Dtos;

namespace Application.Services.Department;

public interface IDepartmentService
{
    Task<DepartmentsDto> GetAllDepartmentsAsync();
    Task<DepartmentDto> GetDepartmentByIdAsync(Guid departmentId);
    Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
    Task<DepartmentDto> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmenttDto);
    Task<DepartmentDto>DeleteDepartmentAsync(Guid departmentId);
}
