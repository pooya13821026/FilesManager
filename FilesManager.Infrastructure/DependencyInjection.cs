using FilesManager.Application.Contracts.Data;
using FilesManager.Application.Contracts.Persistence;
using FilesManager.Application.Contracts.Persistence.AppUser;
using FilesManager.Application.Contracts.Persistence.Dastresi;
using FilesManager.Application.Contracts.Persistence.Eshterak;
using FilesManager.Application.Contracts.Persistence.File;
using FilesManager.Application.Contracts.Persistence.Link;
using FilesManager.Application.Contracts.Persistence.StorageManager;
using FilesManager.Application.Contracts.Services;
using FilesManager.Application.Models.SiteSetting;
using FilesManager.Infrastructure.Data;
using FilesManager.Infrastructure.Implementation.Repositories;
using FilesManager.Infrastructure.Implementation.Repositories.AppUser;
using FilesManager.Infrastructure.Implementation.Repositories.Dastresi;
using FilesManager.Infrastructure.Implementation.Repositories.Eshterak;
using FilesManager.Infrastructure.Implementation.Repositories.File;
using FilesManager.Infrastructure.Implementation.Repositories.Link;
using FilesManager.Infrastructure.Implementation.Repositories.StorageManager;
using FilesManager.Infrastructure.Implementation.Services;
using FilesManager.Infrastructure.Implementation.Services.StorageManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FilesManager.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        var siteSettings = services.BuildServiceProvider()
            .GetRequiredService<IOptionsSnapshot<SiteSettings>>().Value;

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(siteSettings.ConnectionStrings.SqlServer);
        });

        //services.AddIdentity<User, Role>()  // TODO : بررسی بشه
        //    .AddEntityFrameworkStores<ApplicationContext>()
        //    .AddDefaultTokenProviders();

        //services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //{
        //    options.SaveToken = true;
        //    options.RequireHttpsMetadata = false;
        //    options.TokenValidationParameters = new TokenValidationParameters()
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ClockSkew = TimeSpan.Zero,
        //        ValidAudiences = siteSettings.Jwt.ValidAudiences,
        //        ValidIssuer = siteSettings.Jwt.ValidIssuer,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(siteSettings.Jwt.SecurityKey))
        //    };
        //});

        services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
        services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));

        services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

        // Repositories
        services.AddScoped<IDastresiRepository, DastresiWriteRepository>();
        services.AddScoped<IFileRepository, FileWriteRepository>();
        services.AddScoped<ILinkRepository, LinkWriteRepository>();
        services.AddScoped<IEshterakRepository, EshterakWriteRepository>();
        services.AddScoped<IUserRepository, UserWriteRepository>();

        // Services  // TODO : Add Services


        services.AddScoped<IStorageManager, StorageManager>();  

        return services;
    }
}
