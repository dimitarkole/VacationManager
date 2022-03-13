namespace VacationManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VacationManager.Common;
    using VacationManager.Services.Data;
    using VacationManager.Web.Infrastucture.Extensions;
    using VacationManager.Web.Infrastucture.Routes;
    using VacationManager.Web.ViewModels.RoleModels;
    using VacationManager.Web.ViewModels.UserModels;
    using static VacationManager.Common.GlobalConstants;

    [Authorize(Roles = Roles.CEO)]
    [Route("Roles")]
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateInputModel model)
        {
            await this.roleService.Create(model);
            return this.Redirect("/Roles/Index");
        }

        [HttpGet(nameof(Index))]
        public ActionResult Index(int page = GlobalConstants.DefaultPage, int itemsPerPage = GlobalConstants.DefaultItemPerPage)
        {
            var result = this.roleService.All(page, itemsPerPage);
            var routeString = new RouteString(
                nameof(RolesController),
                nameof(this.Index) + "/");
            result.PaginationData.Url = routeString.AppendPaginationPlaceholder();
            result.PaginationData.Url = routeString.AppendItemPerPagePlaceholder();
            return this.View(result);
        }

        [HttpGet(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.roleService.Delete(id);
            return this.Redirect("/Roles/Index");
        }

        [HttpGet(nameof(Edit) + "/{id}")]
        public IActionResult Edit(string id)
        {
            return this.View(this.roleService.GetEditData(id, 1, 10));
        }

        [HttpPost(nameof(Edit) + "/{id}")]
        public async Task<IActionResult> Edit(RoleEditInputModel model, string id)
        {
            await this.roleService.Update(model, id);
            return this.Redirect("/Roles/Index");
        }

        [HttpGet(nameof(Details) + "/{id}")]
        public IActionResult Details(string id, int page = GlobalConstants.DefaultPage, int itemsPerPage = GlobalConstants.DefaultItemPerPage)
        {
            var result = this.roleService.GetById(id, page, itemsPerPage);
            var routeString = new RouteString(
                nameof(RolesController),
                nameof(this.Details));
            result.PaginationData.Url = routeString.AppendId(id);
            result.PaginationData.Url = routeString.AppendPaginationPlaceholder();
            result.PaginationData.Url = routeString.AppendItemPerPagePlaceholder();
            return this.View(result);
        }

        [HttpGet(nameof(DeleteUserRole) + "/{id}")]
        public async Task<IActionResult> DeleteUserRole(string id)
        {
            await this.roleService.DeleteUserRole(id);
            return this.Redirect("/Roles/Index");
        }

        [HttpGet(nameof(CreateUserRole))]
        public IActionResult CreateUserRole()
        {
            //var users = this.roleService.use
            return this.View();
        }

        [HttpPost(nameof(CreateUserRole))]
        public async Task<IActionResult> CreateUserRole(UserRoleCreateModel model)
        {
            await this.roleService.CreateUserRole(model);
            return this.View("/Roles/Details/" + model.RoleId);
        }
    }
}
