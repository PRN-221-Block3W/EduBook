using EduBook.BusinessObject;
using EduBook.Repository.ClassRepository;
using EduBook.Repository.IRepository;
using EduBook.Service.ClassService;
using EduBook.Service.IService;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IAccountService, AccountService>();

			services.AddScoped<IBookingRepository, BookingRepository>();
			services.AddScoped<IBookingService, BookingService>();

			services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<ICommentService, CommentService>();

			services.AddScoped<IRoomRepository, RoomRepository>();
			services.AddScoped<IRoomService, RoomService>();

			services.AddScoped<IRoomEquipmentRepository, RoomEquipmentRepository>();
			services.AddScoped<IRoomEquipmentService, RoomEquipmentService>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentService, EquipmentService>();

            services.AddScoped<IManufactureRepository, ManufactureRepository>();
            services.AddScoped<IManufactureService, ManufactureService>();

            services.AddScoped<IBookingDetailsRepository, BookingDetailsRepository>();
            services.AddScoped<IBookingDetailsService, BookingDetailsService>();

            services.AddScoped<ISlotRepository, SlotRepository>();
            services.AddScoped<ISlotService, SlotService>();
        }
    }
}
