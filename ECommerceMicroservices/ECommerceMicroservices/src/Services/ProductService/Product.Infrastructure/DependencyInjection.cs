using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Product.Application.Common.Interfaces;
using Product.Domain.Repositories;
using Product.Domain.UnitOfWork;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;
using Product.Infrastructure.Services.Inventory;

namespace Product.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ProductDb")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddHttpClient<IInventoryService, InventoryServiceClient>();

        services.Configure<InventoryOptions>(
    configuration.GetSection(InventoryOptions.SectionName));

        services.AddHttpClient<IInventoryService, InventoryServiceClient>(
            (serviceProvider, client) =>
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<InventoryOptions>>()
                    .Value;

                client.BaseAddress = new Uri(options.BaseUrl);
            });

        return services;
    }
}