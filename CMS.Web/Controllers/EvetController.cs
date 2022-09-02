using Clinic.Web.Services.Files;
using CMS.Web.Constant;
using CMS.Web.Data;
using CMS.Web.Models;
using CMS.Web.Services.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    
    public class EventController : BaseController
    {
        private readonly IFileService _fileService;
        private readonly IEventService _eventService;
        public EventController(ApplicationDbContext DB, IFileService fileService, IEventService eventService) : base(DB)
        {
            _eventService = eventService;
            _fileService = fileService;
        }
        //show All Event
        public IActionResult Index()
        {
            return View(_eventService.GetAll().Where(x => x.OrganizationId == organizationId || organizationId == null));
        }
        //Add new Event
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["eventCategory"] = _eventService.SelctEventCategory();
            ViewData["organization"] = _eventService.SelctOrganization();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event model,List<IFormFile> Images)
        {
            model.OrganizationId = organizationId;
            model.CreatedBy = CurrentUserId;
            _eventService.Create(model);

            foreach (var img in Images)
            {
                var imgAddress = await _fileService.SaveFile(img, "Images");
                var eventImage = new EventImage();
                eventImage.EventId = model.Id;
                eventImage.ImageUrl = imgAddress;
                _eventService.AddImage(eventImage);
            }
            _eventService.Save();
            TempData["msg"] = Messages.CreateAction;
            return RedirectToAction("Index");
        }
        //Edit Event
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewData["eventCategory"] = _eventService.SelctEventCategory();
            ViewData["organization"] = _eventService.SelctOrganization();
            return View(_eventService.Get(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Event model, List<IFormFile> Images)
        {
            _eventService.Update(model);
            foreach (var img in Images)
            {
                var imgAddress = await _fileService.SaveFile(img, "Images");
                var eventImage = new EventImage();
                eventImage.EventId = model.Id;
                eventImage.ImageUrl = imgAddress;
                _eventService.UpdateImage(eventImage);
            }

            _eventService.Save();
            TempData["msg"] = Messages.UpdateAction;
            return RedirectToAction("Index");
        }
        // Delete Event
        public IActionResult Delete(int Id)
        {
            _eventService.Delete(Id);
            TempData["msg"] = Messages.DeleteAction;
            return RedirectToAction("Index");
        }
    }
}
