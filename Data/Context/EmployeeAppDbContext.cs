using Data.Configurations;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;
//DbContext
public class EmployeeAppDbContext :  IdentityDbContext<MyUser>
{
    public EmployeeAppDbContext(DbContextOptions<EmployeeAppDbContext> options)
        : base(options) {}

    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Department> Departments { get; set; } = default!;

    public DbSet<Address> Addresses { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
    }
}
