using CMS.Web.Constant;
using CMS.Web.Data;
using CMS.Web.Models;
using CMS.Web.Services.EventCategorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventCategoryController : BaseController
    {
        private readonly IEventCategoryService _eventCategoryService;
        public EventCategoryController(ApplicationDbContext DB, IEventCategoryService eventCategoryService) : base(DB)
        {
            _eventCategoryService = eventCategoryService;
        }
        //Show All EventCategory
        public IActionResult Index()
        {
            return View(_eventCategoryService.GetAll());
        }
        //Add New Event Category
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventCategory model)
        {
            _eventCategoryService.Create(model);
            TempData["msg"] = Messages.CreateAction;
            return RedirectToAction("Index");
        }
        //Edit Event Category
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(_eventCategoryService.Get(Id));
        }
        [HttpPost]
        public IActionResult Edit(EventCategory model)
        {
            _eventCategoryService.Update(model);
            TempData["msg"] = Messages.UpdateAction;
            return RedirectToAction("Index");
        }
        //Delete || Soft Delete
        public IActionResult Delete(int Id)
        {
            _eventCategoryService.Delete(Id);
            TempData["msg"] = Messages.DeleteAction;
            return RedirectToAction("Index");
        }
    }
}
