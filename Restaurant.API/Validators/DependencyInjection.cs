using FluentValidation;
using Restaurant.API.Models.Customer;
using Restaurant.API.Models.Desk;
using Restaurant.API.Models.Employee;
using Restaurant.API.Models.EmployeeRole;
using Restaurant.API.Models.User;

namespace Restaurant.API.Validators;

public static class DependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services
            .AddScoped<IValidator<CreateCustomerModel>, CreateCustomerModelValidator>()
            .AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerModelValidator>()
            .AddScoped<IValidator<CreateDeskModel>, CreateDeskModelValidator>()
            .AddScoped<IValidator<UpdateDeskModel>, UpdateDeskModelValidator>()
            .AddScoped<IValidator<LoginUserModel>, LoginUserModelValidator>()
            .AddScoped<IValidator<CreateEmployeeRoleModel>, CreateEmployeeRoleModelValidator>()
            .AddScoped<IValidator<UpdateEmployeeRoleModel>, UpdateEmployeeRoleModelValidator>()
            .AddScoped<IValidator<CreateEmployeeModel>, CreateEmployeeModelValidator>()
            .AddScoped<IValidator<UpdateEmployeeModel>, UpdateEmployeeModelValidator>()
            .AddScoped<IValidator<EmailVerificationModel>, EmailVerificationModelValidator>();
    }
}
