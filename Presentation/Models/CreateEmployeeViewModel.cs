using Data.Model;

namespace Presentation.Models
{
    public class CreateEmployeeViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public Guid DepartmentId { get; set; } = default!;
        public Address? Address { get; set; } = default!;
    }
}
