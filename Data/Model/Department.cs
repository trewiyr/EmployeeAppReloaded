namespace Data.Model;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<Employee>? Employees { get; set; } 
}
