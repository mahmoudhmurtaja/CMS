using CMS.Web.Constant;
using CMS.Web.Data;
using CMS.Web.Models;
using CMS.Web.Services.PostCategorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostCategoryController : BaseController
    {
        private readonly IPostCategoryService _postCategoryService;
        public PostCategoryController(ApplicationDbContext DB, IPostCategoryService postCategoryService) : base(DB)
        {
            _postCategoryService = postCategoryService;
        }
        public IActionResult Index()
        {
            return View(_postCategoryService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PostCategory model)
        {
            _postCategoryService.Create(model);
            TempData["msg"] = Messages.CreateAction;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(_postCategoryService.Get(Id));
        }
        [HttpPost]
        public IActionResult Edit(PostCategory model)
        {
            _postCategoryService.Update(model);
            TempData["msg"] = Messages.UpdateAction;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _postCategoryService.Delete(Id);
            TempData["msg"] = Messages.DeleteAction;
            return RedirectToAction("Index");
        }
    }
}
