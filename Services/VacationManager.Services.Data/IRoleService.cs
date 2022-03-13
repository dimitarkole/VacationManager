namespace VacationManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using VacationManager.Web.ViewModels.RoleModels;

    public interface IRoleService
    {
        Task Create(RoleCreateInputModel model);

        Task Delete(string id);

        Task DeleteUserRole(string id);

        Task CreateUserRole(UserRoleCreateModel model);

        Task Update(RoleEditInputModel model, string id);

        RolesAllViewModel All(int page, int entitesPerPage);

        RoleDetailsModel GetById(string id, int page, int entitesPerPage);

        RoleEditInputModel GetEditData(string id, int page, int entitesPerPage);
    }
}
