using Application.Dtos;
using Data.Model;

namespace Presentation.Models
{
    public class EmployeeViewModel
    {
        public Guid? Id { get; set; }
        public Guid DepartmentId { get; set; }
        public List<DepartmentDto>? Departments { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public Address? Address {  get; set; }
    
    }
}
