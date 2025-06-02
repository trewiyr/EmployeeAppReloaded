using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Department
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeAppDbContext _context;

        public EmployeeService(EmployeeAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees.Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
