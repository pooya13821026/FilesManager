
namespace FilesManager.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddApplicationServices(builder.Configuration);
            //builder.Services.AddInfrastructureServices();

            //await builder.Services.InitializeDatabaseAsync();

            //builder.Services.AddCors(config =>
            //{
            //    config.AddPolicy(CorsPolicyName, options =>
            //    {
            //        var validOrigins = builder.Configuration
            //            .GetSection("Cors:Valid").Get<List<string>>();

            //        options.WithOrigins(validOrigins!.ToArray())
            //            .AllowAnyMethod()
            //            .AllowAnyHeader();
            //    });
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
