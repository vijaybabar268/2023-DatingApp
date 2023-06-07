using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);
        {
            builder.Services.AddControllers();            
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);            
        }

        // Configure the HTTP request pipeline.
        var app = builder.Build();
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));
            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                context.Database.MigrateAsync();
                Seed.SeedUsersAsync(context);
            }
            catch (Exception ex)
            {                
                var logger = services.GetService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }

            app.Run();
        }
    }
}