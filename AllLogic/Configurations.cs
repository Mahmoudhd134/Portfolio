using System.Reflection;
using AllLogic.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AllLogic;

public static class Configurations
{
    private static readonly Assembly Assembly = typeof(Configurations).Assembly;
    public static IServiceCollection AddAllLogicConfiguration(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<IdentityContext>(opt =>
            opt.UseSqlServer(connectionString));

        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly));

        services.AddAutoMapper(conf => conf.AddMaps(Assembly));
        
        return services;
    }
}