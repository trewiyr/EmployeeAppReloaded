using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Department
{
     public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
    }
}
