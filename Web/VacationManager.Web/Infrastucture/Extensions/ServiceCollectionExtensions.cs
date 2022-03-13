namespace VacationManager.Web.Infrastucture.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VacationManager.Data;
    using VacationManager.Data.Common;
    using VacationManager.Data.Common.Repositories;
    using VacationManager.Data.Models;
    using VacationManager.Data.Repositories;
    using VacationManager.Services;
    using VacationManager.Services.Messaging;
    using VacationManager.Web.Infrastucture.Configurations;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using VacationManager.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using VacationManager.Services.Data;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddCookie(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(
               options =>
               {
                   options.CheckConsentNeeded = context => true;
                   options.MinimumSameSitePolicy = SameSiteMode.None;
               });

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>
                (options =>
                    {
                        //Remove password rules if we are in development environment
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequiredUniqueChars = 0;
                    })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
            => services
                .AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>))
                .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped<IDbQueryRunner, DbQueryRunner>()
                .AddTransient<IEmailSender, NullMessageSender>()
                .AddTransient<IPaginationService, PaginationService>()
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<ITeamService, TeamService>();

        public static IServiceCollection ApplyControllersWithViews(this IServiceCollection services)
        {
            services.AddControllersWithViews(
               options =>
               {
                   options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
               })
            .AddRazorRuntimeCompilation();

            return services;
        }
    }
}
