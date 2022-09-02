using Clinic.Web.Services.Emails;
using Clinic.Web.Services.Files;
using CMS.Web.Constant;
using CMS.Web.Data;
using CMS.Web.Models;
using CMS.Web.Services.Posts;
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

    
    public class PostController : BaseController
    {
        private readonly IFileService _fileService;
        private readonly IEmailSender _emailSender;
        private readonly IPostService _postService;
        
        public PostController(ApplicationDbContext DB, IFileService fileService, IEmailSender emailSender, IPostService postService) : base(DB)
        {
            _fileService = fileService;
            _emailSender = emailSender;
            _postService = postService;
        }
        
        public IActionResult Index()
        {
            return View(_postService.GetAll().Where(x => x.OrganizationId == organizationId || organizationId == null));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["postCategory"] = _postService.SelectpostCategory();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post model,IFormFile imgFile, IFormFile attachmentFile)
        {
            var imgAddress = await _fileService.SaveFile(imgFile,"Images");
            var attachmentAddress = await _fileService.SaveFile(attachmentFile, "Attachments");

            model.OrganizationId = organizationId;
            model.CreatedBy = CurrentUserId;
            model.ImageUrl = imgAddress;
            model.AttachmentUrl = attachmentAddress;
            _postService.Create(model);

            await _emailSender.Send("ahmedbbnn122@gmail.com", "تطعيم كورنا", "تمت تطعيمك اليوم اذا ظهرت عليك اي اعراض الزومبي الرجاء المراجعة لاقرب مكان  ");

            TempData["msg"] = Messages.CreateAction;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewData["postCategory"] = _postService.SelectpostCategory();
            return View(_postService.Get(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post model, IFormFile imgFile, IFormFile attachmentFile)
        {
            
            var imgAddress = await _fileService.SaveFile(imgFile, "Images");
            var attachmentAddress = await _fileService.SaveFile(attachmentFile, "Attachments");
            
            model.UpdateAt = DateTime.Now;
            model.UpdateBy = CurrentUserId;
            model.ImageUrl = imgAddress;
            model.AttachmentUrl = attachmentAddress;

            _postService.Update(model);
            TempData["msg"] = Messages.UpdateAction;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _postService.Delete(Id);
            TempData["msg"] = Messages.DeleteAction;
            return RedirectToAction("Index");
        }
    }
}
