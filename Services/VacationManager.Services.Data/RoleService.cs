namespace VacationManager.Services.Data
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VacationManager.Common.Extensions;
    using VacationManager.Data;
    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.PaginationModels;
    using VacationManager.Web.ViewModels.RoleModels;
    using VacationManager.Web.ViewModels.UserModels;

    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext context;
        private readonly IPaginationService paginationService;

        public RoleService(
            ApplicationDbContext context,
            IPaginationService paginationService)
        {
            this.context = context;
            this.paginationService = paginationService;
        }

        public RolesAllViewModel All(int page, int entitesPerPage)
        {
            var roles = this.context.Roles
                .OrderBy(r => r.Name)
                .To<RoleViewModel>();

            var paginationData = new PaginationData()
            {
                CurrentPage = page,
                ItemsPerPage = entitesPerPage,
                NumberOfPages = this.GetItemsPagesCount(roles.Count(), entitesPerPage),
            };

            return new RolesAllViewModel()
            {
                Roles = roles
                    .GetPage(page, entitesPerPage)
                    .ToList(),
                PaginationData = paginationData,
            };
        }

        public async Task Create(RoleCreateInputModel model)
        {
            var role = model.To<ApplicationRole>();
            await this.context.Roles.AddAsync(role);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var role = this.context.Roles.Find(id);
            this.context.Roles.Remove(role);

            await this.context.SaveChangesAsync();
        }

        public RoleEditInputModel GetEditData(string id, int page, int entitesPerPage)
            => this.context.Roles
                .Where(r => r.Id == id)
                .To<RoleEditInputModel>()
                .FirstOrDefault();

        public RoleDetailsModel GetById(string id, int page, int entitesPerPage)
        {
            var role = this.context.Roles
                .Where(r => r.Id == id)
                .To<RoleViewModel>()
                .FirstOrDefault();

            var users = this.context.Users
                .Where(u => u.Roles.Any(r => r.RoleId == id))
                .To<UserViewModel>();

            var paginationData = new PaginationData()
            {
                CurrentPage = page,
                ItemsPerPage = entitesPerPage,
                NumberOfPages = this.GetItemsPagesCount(users.Count(), entitesPerPage),
            };

            return new RoleDetailsModel()
            {
                Role = role,
                TotalUsersCount = users.Count(),
                Users = users
                    .GetPage(page, entitesPerPage)
                    .ToList(),
                PaginationData = paginationData,
            };
        }

        public async Task Update(RoleEditInputModel model, string id)
        {
            var role = this.context.Roles.Find(id);
            model.To<ApplicationRole>(role);

            this.context.Roles.Update(role);
            await this.context.SaveChangesAsync();
        }

        private int GetItemsPagesCount(int entityCount, int entitesPerPage)
           => this.paginationService.CalculatePagesCount(entityCount, entitesPerPage);

        public async Task DeleteUserRole(string id)
        {
            var userRole = this.context.UserRoles.Find(id);
            this.context.UserRoles.Remove(userRole);

            await this.context.SaveChangesAsync();
        }

        public async Task CreateUserRole(UserRoleCreateModel model)
        {
            var userRole = model.To<IdentityUserRole<string>>();
            await this.context.UserRoles.AddAsync(userRole);
            await this.context.SaveChangesAsync();
        }
    }
}
