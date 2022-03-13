namespace VacationManager.Web.Areas.Administration.Controllers
{
    using VacationManager.Common;
    using VacationManager.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.Roles.Administrator)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
