using ItAcademy.Application.Accounts.Repositories;
using ItAcademy.Application.Accounts;
using ItAcademy.Application.Events.Repositories;
using ItAcademy.Application.Events;
using ItAcademy.Application.Orders.Repositories;
using ItAcademy.Application.Orders;
using ItAcademy.Infrastructure.BaseRepo;
using ItAcademy.Infrastructure.Events;
using ItAcademy.Infrastructure.Orders;
using ItAcademy.Infrastructure.Users;

namespace Events.ItAcademy.Ge.MVC.Services
{
    public static class ServiceInjetionMiddlewareExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IOrderService, OrderService>();

            #region AddRepos
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            #endregion
        }
    }
}
