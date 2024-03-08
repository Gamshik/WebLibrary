
using Domain.Context;
using Microsoft.AspNetCore.Identity;
using WebApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConnectDatabase(builder);

            builder.Services.ConfigureIdentity();

            builder.Services.ConfigureSwagger();

            builder.Services.ConfigureLogger();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureDependencies();

            builder.Services.ConfigureMapper();

            builder.Services.ConfigureJwt(builder);

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.MigrateDatabase<ApplicationContext>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
