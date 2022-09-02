using Clinic.Web.Services.Emails;
using CMS.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
   [Authorize]
    public class BaseController : Controller
    {
        protected string UserName { get; set; }
        protected readonly ApplicationDbContext _DB;
        protected int? organizationId;
        protected string CurrentUserId;

        

        public BaseController(ApplicationDbContext DB)
        {
            _DB = DB;
           
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            UserName = User.Identity.Name;
            var user = _DB.Users.SingleOrDefault(x => x.UserName == UserName);
            organizationId = user.OrganizationId;
            CurrentUserId = user.Id;
            TempData["UserType"] = user.UserType;
        }
    }
}
