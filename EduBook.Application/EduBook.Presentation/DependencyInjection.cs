﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduBook.Presentation
{
    /// <summary>
    /// Functions for create dependency injections
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// This function to add dependency injection for NuGet Package
        /// </summary>
        /// <param name="services"></param>
        public static void AddPackage(this IServiceCollection services)
        {
            //Session
            services.AddSession();
        }

        /// <summary>
        /// Create dependencies for service (interface) & service (class) or repository (interface) & repository (class)
        /// </summary>
        /// <param name="services"></param>
        public static void AddMasterServices(this IServiceCollection services)
        {
            //Example code:
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
