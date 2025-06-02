namespace Presentation.Models
{
    public class DepartmentDetailViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; } = default!;
    }
}
