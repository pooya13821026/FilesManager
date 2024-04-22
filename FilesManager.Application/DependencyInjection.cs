using FilesManager.Application.Behaviors;
using FilesManager.Application.Common.Validations;
using FilesManager.Application.Models.SiteSetting;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FilesManager.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, Action<SiteSettings> configuration)
    {
        //services.AddHttpContextAccessor(); // TODO

        services.Configure<SiteSettings>(configuration);

        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient<StorageFileValidator>();

        return services;
    }
}
