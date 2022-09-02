using CMS.Web.Constant;
using CMS.Web.Data;
using CMS.Web.Dto;
using CMS.Web.Models;
using CMS.Web.Services.Users;
using CMS.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _UserManager;
        private readonly IUserService _userService;
        
        public UserController(ApplicationDbContext DB, UserManager<User> UserManager, IUserService userService) : base(DB)
        {
            _UserManager = UserManager;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["organization"] = _userService.SelectOrganization();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            if (_userService.IsExist(dto))
            {
                TempData["msg"] = Messages.DublicatedUserName;
                return View();
            }
            var user = new User();
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = CurrentUserId;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.Mobile;
            user.UserType = dto.Type;
            user.Gender = dto.Gender;
            user.UserName = dto.Email;
            user.OrganizationId = dto.OrganizationId;

            var result = await _UserManager.CreateAsync(user,"Ahmed111$$");
            if (result.Succeeded)
            {
                if (user.UserType == Enums.UserType.Admin)
                {
                    await _UserManager.AddToRoleAsync(user,"Admin");
                }else if (user.UserType == Enums.UserType.OrganizationAdmin)
                {
                    await _UserManager.AddToRoleAsync(user, "OrganizationAdmin");
                }
                else if (user.UserType == Enums.UserType.User)
                {
                    await _UserManager.AddToRoleAsync(user, "User");
                }
            }
            TempData["msg"] = Messages.CreateAction;
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(string Id)
        {
            _userService.Delete(Id);
            TempData["msg"] = Messages.DeleteAction;
            return RedirectToAction("Index");
        }
    }
}
