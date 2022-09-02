using CMS.Web.Data;
using CMS.Web.Dto;
using CMS.Web.Models;
using CMS.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _DB;
        
        public UserService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public List<UserViewModel> GetAll()
        {
            var users = _DB.Users.Where(x => !x.IsDelete).ToList();
            var usersVm = new List<UserViewModel>();
            foreach (var item in users)
            {
                var userVm = new UserViewModel();
                userVm.Id = item.Id;
                userVm.FullName = item.FirstName + " " + item.LastName;
                userVm.Email = item.Email;
                userVm.Mobile = item.PhoneNumber;
                userVm.UserType = item.UserType;
                userVm.Gender = item.Gender;
                usersVm.Add(userVm);
               
            }
            return (usersVm);
        }
        
        public SelectList SelectOrganization()
        {
            return (new SelectList(_DB.Organizations.Where(x => !x.IsDelete), "Id", "Name"));
        }
        public void Delete(string Id)
        {
            var user = _DB.Users.SingleOrDefault(x => !x.IsDelete && x.Id == Id);
            user.IsDelete = true;
            _DB.Users.Update(user);
            _DB.SaveChanges();
        }
        public bool IsExist(CreateUserDto dto)
        {
            return (_DB.Users.Any(x => x.Email == dto.Email || x.PhoneNumber == dto.Mobile));
        }
    }
}
