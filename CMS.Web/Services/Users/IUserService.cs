using CMS.Web.Dto;
using CMS.Web.Models;
using CMS.Web.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Users
{
    public interface IUserService
    {
        public List<UserViewModel> GetAll();
        public SelectList SelectOrganization();
        public void Delete(string Id);
        public bool IsExist(CreateUserDto dto);
    }
}
