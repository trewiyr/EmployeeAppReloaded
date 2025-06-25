using Application.Services.Address;
using Application.Services.Department;
using Application.Services.Email;
using Application.Services.Employee;
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

    public static IServiceCollection AddAServices(this IServiceCollection services)
    {
        services.AddScoped<IAddressService, AddressService>();

        return services;
    }
    public static IServiceCollection AddMServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
