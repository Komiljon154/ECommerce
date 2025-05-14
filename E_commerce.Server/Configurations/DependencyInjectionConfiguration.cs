using E_commerce.Bll.Services;
using E_commerce.PaymentBroker.Services;
using E_commerce.Repository.Services;

namespace E_commerce.Server.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICardRepository, CardRepository>();

        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartService, CartService>();

        services.AddScoped<ICartProductRepository, CartProductRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrederProductRepository, OrederProductRepository>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IPaymentService, PaymentService>();
    }
}
