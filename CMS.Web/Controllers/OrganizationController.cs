using CMS.Web.Constant;
using CMS.Web.Data;
using CMS.Web.Models;
using CMS.Web.Services.Organizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(ApplicationDbContext DB, IOrganizationService organizationService): base(DB)
        {
            _organizationService = organizationService;
        }
        public IActionResult Index()
        {
           return View(_organizationService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Organization model)
        {
            _organizationService.Create(model);
            TempData["msg"] = Messages.CreateAction;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(_organizationService.Get(Id));
        }
        [HttpPost]
        public IActionResult Edit(Organization model)
        {
            _organizationService.Update(model);
            TempData["msg"] = Messages.UpdateAction;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _organizationService.Delete(Id);
            TempData["msg"] = Messages.DeleteAction;
            return RedirectToAction("Index");
        }
    }
}
