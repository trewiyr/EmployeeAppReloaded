using Application.Services.Department;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ApplicationServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();

        return services;
    }
    public static IServiceCollection AddEServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}
