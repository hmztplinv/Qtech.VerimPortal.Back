using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) // IServiceCollection extend ediyoruz
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); 
            // MediatR'ı kullanarak Assembly.GetExecutingAssembly() içerisindeki tüm servisleri register et.
        });
        return services;
    }
}