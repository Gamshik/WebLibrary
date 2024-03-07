using Domain.Classes;
using Domain.Context;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using Domain.Interfaces;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();

            LogManager.Setup().LoadConfigurationFromFile("..\\Logs\\nlog.config");
        }
        public static void ConnectDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), b => b.MigrationsAssembly("WebApi")));
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;

                opt.Password.RequiredLength = 10;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;

                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
            });
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, LoggerService>();
        }
    }
}
