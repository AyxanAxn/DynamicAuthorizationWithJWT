using CrocusoftTask.AppDBContext;
using CrocusoftTask.Repositories.IRepository.IPermissionRepository;
using CrocusoftTask.Repositories.IRepository.IRoleRepository;
using CrocusoftTask.Repositories.IRepository.IUserRepository;
using CrocusoftTask.Repositories.Repository.PermissionRepository;
using CrocusoftTask.Repositories.Repository.RoleRepository;
using CrocusoftTask.Repositories.Repository.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskOfCrocusoft.Abstractions.Services;
using TaskOfCrocusoft.Services.Token;

namespace CrocusoftTask.ServiceConfig
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();

            services.AddScoped<IPermissionReadRepository, PermissionReadRepository>();
            services.AddScoped<IPermissionWriteRepository, PermissionWriteRepository>();

            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}