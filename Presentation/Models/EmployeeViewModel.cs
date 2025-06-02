using Data.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models
{
    public class EmployeeViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = default!;

        public Guid DepartmentId { get; set; }

        public List<Employee> Departments { get; set; } = new List<Employee>();
    }
}
