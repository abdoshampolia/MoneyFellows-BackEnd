using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MoneyFellows.Application.Features.Accounts.Commands.RegisterAdmin;
using MoneyFellows.Application.Features.Accounts.Commands.RegisterUser;
using MoneyFellows.Application.Features.Orders.Commands.CreateOrder;
using MoneyFellows.Application.Features.Orders.Commands.UpdateOrder;
using MoneyFellows.Application.Features.Products.Commands.CreateProduct;
using MoneyFellows.Application.Features.Products.Commands.UpdateProduct;

namespace MoneyFellows.Infrastructure
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
            services.AddTransient<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();
            services.AddTransient<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            services.AddTransient<IValidator<UpdateOrderCommand>, UpdateOrderCommandValidator>();
            services.AddTransient<IValidator<RegisterAdminCommand>, RegisterAdminCommandValidator>();
            services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
            return services;
        }
    }
}
