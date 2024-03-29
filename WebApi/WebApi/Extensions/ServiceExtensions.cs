﻿using AutoMapper;
using Contracts;
using Entities;
using Entities.DTOs.UserDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using System.Text;
using Validation.Config;
using WebApi.BLL.Services;
using WebApi.BLL.Services.ValidationServices;
using WebApi.DAL.Context;
using WebApi.DAL.Repositories;
using WebApi.Profiles;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();

            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\nlog.config"));
        }
        public static void ConnectDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), b => b.MigrationsAssembly("WebApi")));
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationContext>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;

                opt.Password.RequiredLength = 10;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;

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
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IValidator<UserRegistrationDto>, UserRegistrationValidator>();
            services.AddScoped<IValidator<BookPreview>, BookPreviewValidator>();
            services.AddScoped<IValidator<TextOfBook>, TextOfBookValidator>();
            services.AddScoped<IUserEntitiesValidationService, UserEntitiesValidationService>();
            services.AddScoped<IBookEntitiesValidationService, BookEntitiesValidationService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
        public static void ConfigureJwt(this IServiceCollection services, WebApplicationBuilder application)
        {
            var jwtSetting = application.Configuration.GetSection("Jwt");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSetting.GetSection("Issuer").Value,
                    ValidAudience = jwtSetting.GetSection("Audience").Value,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.GetSection("SecurityKey").Value)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new UserProfile(),
                    new BookPreviewProfile(),
                    new TextOfBookProfile()
                });
            });

            services.AddScoped<IMapper>(x => new Mapper(config));
        }
    }
}
