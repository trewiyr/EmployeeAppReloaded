using Application.ContractMapping;
using Application.Dtos;
using Application.Services.Employee;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Datatypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services.Department
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeAppDbContext _context;

        public EmployeeService(EmployeeAppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeesDto> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
        .Include(e => e.Department)
        .ToListAsync();

            return employees.EmployeesDto();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
           var employee =  await _context.Employees.Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
            return employee!.ToDto();
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            var data = new CreateEmployeeDto
            {
                Id = Guid.NewGuid(),
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                Email = createEmployeeDto.Email,
                HireDate = createEmployeeDto.HireDate,
                Salary = createEmployeeDto.Salary,
                DepartmentId = createEmployeeDto.DepartmentId
           
            };
            var employee = data.ToModel();
           
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.ToDto();
            
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var employee = _context.Employees.FirstOrDefault(d => d.Id == dto.Id);


            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.HireDate = dto.HireDate;
            employee.Salary = dto.Salary;


            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                return employee.ToDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the department.", ex);
                return new EmployeeDto();
            }

        }
        public async Task<EmployeeDto> DeleteEmployeeAsync(Guid departmentId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(d => d.Id == departmentId);
            _context.Employees.Remove(employee!);
            await _context.SaveChangesAsync();
            return employee?.ToDto()!;
        }


    }
}
